namespace CompanyRegisterApi.Models
{
	public class AddCompanyRequest
	{
		public string Name { get; set; }

		public int INN { get; set; }

		public int OGRN { get; set; }
	}
}
