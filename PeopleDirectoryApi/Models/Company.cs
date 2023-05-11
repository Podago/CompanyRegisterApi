using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleDirectoryApi.Models
{
	public class Company
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public int INN { get; set; }

		public int OGRN { get; set; }

		public List<Employee> Employees { get; set; }

		public List<Address> Addresses { get; set; }

		public List<Property> Property { get; set; }
	}
}
