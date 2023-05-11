using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi.Models;

namespace PeopleDirectoryApi.ModelBuilders
{
	public class EmployeeModelBuilder
	{
		internal static void Build(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>(entity =>
			{
				entity
					.ToTable("Employees")
				.HasKey(x => x.Id);

				entity.Property(x => x.Id).IsRequired().HasColumnName("Id"); 

				entity.Property(x => x.Status).IsRequired().HasColumnName("Status");

				entity.Property(x => x.CompanyId).IsRequired().HasColumnName("CompanyId");
			});
		}
	}
}
