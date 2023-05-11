using CompanyRegisterApi.Interfaces;
using CompanyRegisterApi.Models;
using Microsoft.AspNetCore.Mvc;
using PeopleDirectoryApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyRegisterApi.Controllers
{
	[Route("api/company/employee")]
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet()]
		public async Task<ActionResult<List<Employee>>> GetEmployees(int companyId)
		{
			var employees = await _employeeService.GetEmployees(companyId);

			return Ok(employees);
		}

		[HttpPost()]
		public async Task<ActionResult> AddEmployee(AddEmployeeRequest companyRequest)
		{
			await _employeeService.AddEmployee(companyRequest);

			return Ok();
		}

		[HttpPut()]
		public async Task<ActionResult> UpdateEmployeeAsync(UpdateEmployeeRequest employeeRequest)
		{
			await _employeeService.UpdateEmployeeAsync(employeeRequest);

			return Ok();
		}

		[HttpDelete()]
		public async Task<ActionResult> DeleteEmployeeAsync(int employeeId)
		{
			await _employeeService.DeleteEmployeeAsync(employeeId);

			return Ok();
		}
	}
}
