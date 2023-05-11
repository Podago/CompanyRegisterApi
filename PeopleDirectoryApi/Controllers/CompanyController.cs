using CompanyRegisterApi.Models;
using Microsoft.AspNetCore.Mvc;
using PeopleDirectoryApi.Interfaces;
using PeopleDirectoryApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleDirectoryApi.Controllers
{
	[Route("api/company")]
	public class CompanyController : Controller
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[HttpGet("all")]
		public async Task<ActionResult<List<Company>>> GetAllCompanies()
		{
			var companies = await _companyService.GetAllCompanies();

			return Ok(companies);
		}

		[HttpPost()]
		public async Task<ActionResult<Company>> AddCompany(AddCompanyRequest companyRequest)
		{
			var result = await _companyService.AddCompany(companyRequest);

			return Ok(result);
		}
	}
}
