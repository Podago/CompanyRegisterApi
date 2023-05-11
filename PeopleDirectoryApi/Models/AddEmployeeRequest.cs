namespace CompanyRegisterApi.Models
{
	public class AddEmployeeRequest
	{
		public string Passport { get; set; }

		public string Snils { get; set; }

		public string Name { get; set; }

		public string Lastname { get; set; }

		public string Surname { get; set; }

		public int CompanyId { get; set; }
	}
}
