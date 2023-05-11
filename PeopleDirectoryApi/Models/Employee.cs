using PeopleDirectoryApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleDirectoryApi.Models
{
	public class Employee
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public Status Status { get; set; }

		public EmployeeInfo EmployeeInfo { get; set; }

		public int CompanyId { get; set; }

		public Company Company { get; set; }
	}
}
