using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservice.Api2.Core.Models.Entities;

namespace Microservice.Api2.Infrastructure.Data
{
    public class Api2Context : DbContext
    {
        //protected readonly IConfiguration _configuration;
        public Api2Context()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        //public Api2Context(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public Api2Context(DbContextOptions<Api2Context> options) : base(options)
        {
            //ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            //options.UseSqlServer(_configuration.GetConnectionString(Constants.DbConnectionStringKey));
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(ConfigureEmployee);
        }
        private void ConfigureEmployee(EntityTypeBuilder<Employee> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Employee").HasKey(t => t.EmployeeId);
            entityTypeBuilder.Property(e => e.EmployeeId).ValueGeneratedOnAdd().UseIdentityColumn();
            entityTypeBuilder.Property(e => e.EmployeeNumber).IsRequired();
            entityTypeBuilder.Property(e => e.Title).IsRequired(false).HasMaxLength(60);
            entityTypeBuilder.Property(e => e.FirstName).IsRequired().HasMaxLength(200);
            entityTypeBuilder.Property(e => e.LastName).IsRequired().HasMaxLength(200);
            entityTypeBuilder.Property(e => e.BirthDate).IsRequired();
            entityTypeBuilder.Property(e => e.HireDate).IsRequired();
            entityTypeBuilder.Property(e => e.Salary).HasColumnType("decimal(16, 3)").IsRequired();
            entityTypeBuilder.Property(e => e.Designation).IsRequired(false);
            entityTypeBuilder.Property(e => e.Department).IsRequired(false);
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
