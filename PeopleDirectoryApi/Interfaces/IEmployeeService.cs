using CompanyRegisterApi.Models;
using Microsoft.AspNetCore.Mvc;
using PeopleDirectoryApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyRegisterApi.Interfaces
{
	public interface IEmployeeService
	{
		Task<List<Employee>> GetEmployees(int companyId);

		Task AddEmployee(AddEmployeeRequest employeeRequest);

		Task UpdateEmployeeAsync(UpdateEmployeeRequest employeeRequest);

		Task DeleteEmployeeAsync(int employeeId);
	}
}
