using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleDirectoryApi.Models
{
	public class Property
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public int Cost { get; set; }

		public int CompanyId { get; set; }

		public Company Company { get; set; }
	}
}
