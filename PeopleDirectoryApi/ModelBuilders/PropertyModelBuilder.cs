using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi.Models;

namespace PeopleDirectoryApi.ModelBuilders
{
	public class PropertyModelBuilder
	{
		internal static void Build(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Property>(entity =>
			{
				entity
					.ToTable("Property")
					.HasKey(x => x.Id);

				entity.Property(x => x.Id).IsRequired().HasColumnName("Id");

				entity.Property(x => x.Name).IsRequired().HasColumnName("Name");

				entity.Property(x => x.Cost).IsRequired().HasColumnName("Cost");
			});
		}
	}
}