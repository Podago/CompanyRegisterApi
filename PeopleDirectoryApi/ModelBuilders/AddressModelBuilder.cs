using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi.Models;

namespace PeopleDirectoryApi.ModelBuilders
{
	public class AddressModelBuilder
	{
		internal static void Build(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Address>(entity =>
			{
				entity
					.ToTable("Addresses")
					.HasKey(x => x.Id);

				entity.Property(x => x.Id).IsRequired().HasColumnName("Id");

				entity.Property(x => x.AddressName).IsRequired().HasColumnName("AddressName");

				entity.Property(x => x.Status).IsRequired().HasColumnName("Status");

				entity.Property(x => x.CompanyId).IsRequired().HasColumnName("CompanyId");
			});
		}
	}
}
