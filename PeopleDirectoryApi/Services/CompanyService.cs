using CompanyRegisterApi.Models;
using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi.Interfaces;
using PeopleDirectoryApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleDirectoryApi.Services
{
    public class CompanyService : ICompanyService
	{
		private readonly CompanyRegisterDbContext _companyRegisterDbContext;

		public CompanyService(CompanyRegisterDbContext companyRegisterDbContext)
		{
			_companyRegisterDbContext = companyRegisterDbContext;
		}

		public async Task<List<Company>> GetAllCompanies()
		{
			var company =  await _companyRegisterDbContext
				.Companies
				.AsNoTracking()
				.Include(x => x.Employees)
				.Include(x => x.Addresses)
				.Include(x => x.Property)
				.ToListAsync();

			return company;
		}

		public async Task<Company> AddCompany(AddCompanyRequest companyRequest)
		{
			var company = new Company
			{
				Name = companyRequest.Name,

				INN = companyRequest.INN,

				OGRN = companyRequest.OGRN
			};

			await _companyRegisterDbContext
				.Companies
				.AddAsync(company);

			await _companyRegisterDbContext.SaveChangesAsync();

			return company;
		}
	}
}
