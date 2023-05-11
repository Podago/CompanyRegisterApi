using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi.Models;
using System;

namespace PeopleDirectoryApi.ModelBuilders
{
	public class EmployeeInfoModelBuilder
	{
		internal static void Build(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EmployeeInfo>(entity =>
			{
				entity
					.ToTable("EmployeeInfos")
					.HasKey(x => x.Id);

				entity.Property(x => x.Id).IsRequired().HasColumnName("Id");

				entity.Property(x => x.EmployeeId).IsRequired().HasColumnName("EmployeeId");

				entity.Property(x => x.Passport).IsRequired().HasColumnName("Passport");

				entity.Property(x => x.Snils).IsRequired().HasColumnName("Snils");

				entity.Property(x => x.Name).IsRequired().HasColumnName("Name");

				entity.Property(x => x.Lastname).IsRequired().HasColumnName("Lastname");

				entity.Property(x => x.Surname).IsRequired().HasColumnName("Surname");

				entity.HasOne(x => x.Employee).WithOne(x => x.EmployeeInfo).HasPrincipalKey<EmployeeInfo>(x => x.EmployeeId).HasForeignKey<Employee>(x => x.Id);
			});
		}
	}
}
