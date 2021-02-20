using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Microservice.ServiceBusSubscription.DurableFunctions.Configuration;
using Microservice.ServiceBusSubscription.DurableFunctions.Models;

namespace Microservice.ServiceBusSubscription.DurableFunctions.Orchestrations
{
    public class Api2Orchestration
    {
        [FunctionName(Constants.Api2OrchestrationFunction)]
        public async Task<bool> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context, ILogger logger)
        {
            var result =  await context.CallActivityAsync<bool>(Constants.Api2PayloadPostActivityFunction, context.GetInput<EmployeePayload>());
            if (!context.IsReplaying)
            {
                logger.LogInformation($"{Constants.Api2PayloadPostActivityFunction} completed.");
            }
            return result;
        }
    }
}