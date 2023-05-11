using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi.ModelBuilders;
using PeopleDirectoryApi.Models;

namespace PeopleDirectoryApi
{
    public class CompanyRegisterDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Property> Property { get; set; }

		public CompanyRegisterDbContext(DbContextOptions<CompanyRegisterDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EmployeeModelBuilder.Build(modelBuilder);

            EmployeeInfoModelBuilder.Build(modelBuilder);

            AddressModelBuilder.Build(modelBuilder);

            CompanyModelBuilder.Build(modelBuilder);

            PropertyModelBuilder.Build(modelBuilder);
		}
    }
}
