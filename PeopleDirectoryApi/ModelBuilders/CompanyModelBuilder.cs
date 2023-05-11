using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi.Models;

namespace PeopleDirectoryApi.ModelBuilders
{
	public class CompanyModelBuilder
	{
		internal static void Build(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>(entity =>
			{
				entity
					.ToTable("Companies")
					.HasKey(x => x.Id);

				entity.Property(x => x.Id).IsRequired().HasColumnName("Id");

				entity.Property(x => x.Name).IsRequired().HasColumnName("Name");

				entity.Property(x => x.INN).IsRequired().HasColumnName("INN");

				entity.Property(x => x.OGRN).IsRequired().HasColumnName("OGRN");

				entity.HasMany(x => x.Employees).WithOne(x => x.Company).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.CompanyId);

				entity.HasMany(x => x.Addresses).WithOne(x => x.Company).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.CompanyId);

				entity.HasMany(x => x.Property).WithOne(x => x.Company).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.CompanyId);
			});
		}
	}
}