using CompanyRegisterApi.Models;
using PeopleDirectoryApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleDirectoryApi.Interfaces
{
	public interface ICompanyService
	{
		Task<List<Company>> GetAllCompanies();

		Task<Company> AddCompany(AddCompanyRequest companyRequest);
	}
}
