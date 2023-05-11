using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleDirectoryApi.Models
{
	public class EmployeeInfo
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int EmployeeId { get; set; }

		public Employee Employee { get; set; }

		public string Passport { get; set; }

		public string Snils { get; set; }

		public string Name { get; set; }

		public string Lastname { get; set; }

		public string Surname { get; set; }
	}
}
