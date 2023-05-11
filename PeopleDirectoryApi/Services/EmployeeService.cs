using CompanyRegisterApi.Interfaces;
using CompanyRegisterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleDirectoryApi;
using PeopleDirectoryApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRegisterApi.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly CompanyRegisterDbContext _companyRegisterDbContext;

		public EmployeeService(CompanyRegisterDbContext companyRegisterDbContext)
		{
			_companyRegisterDbContext = companyRegisterDbContext;
		}

		public async Task AddEmployee(AddEmployeeRequest employeeRequest)
		{
			var company = await _companyRegisterDbContext
			.Companies
					.FirstOrDefaultAsync(c => c.Id == employeeRequest.CompanyId);

			if (company == null)
			{
				return;
			}

			var employee = new Employee
			{
				Status = 0,
				CompanyId = employeeRequest.CompanyId
			};

			await _companyRegisterDbContext
				.Employees
				.AddAsync(employee);

			await _companyRegisterDbContext.SaveChangesAsync();

			var employeeInfo = new EmployeeInfo
			{
				Passport = employeeRequest.Passport,
				Snils = employeeRequest.Snils,
				Name = employeeRequest.Name,
				Lastname = employeeRequest.Lastname,
				Surname = employeeRequest.Surname,
				EmployeeId = employee.Id
			};

			await _companyRegisterDbContext
				.EmployeeInfos
				.AddAsync(employeeInfo);

			await _companyRegisterDbContext.SaveChangesAsync();
		}

		public async Task<List<Employee>> GetEmployees(int companyId)
		{
			var company = await _companyRegisterDbContext
					.Companies
					.FirstOrDefaultAsync(c => c.Id == companyId);

			if (company == null)
			{
				return null;
			}

			var employees = await _companyRegisterDbContext
				.Employees
				.Include(e => e.EmployeeInfo)
				.Where(e => e.CompanyId == companyId)
				.ToListAsync();

			return employees;
		}

		public async Task UpdateEmployeeAsync(UpdateEmployeeRequest employeeRequest)
		{
			var employee = await _companyRegisterDbContext
					.Employees
					.FirstOrDefaultAsync(c => c.Id == employeeRequest.EmployeeId);

			if (employee == null)
			{
				return;
			}

			var company = await _companyRegisterDbContext
					.Companies
					.FirstOrDefaultAsync(c => c.Id == employeeRequest.CompanyId);

			if (company == null)
			{
				return;
			}

			var employeeInfo = await _companyRegisterDbContext
					.EmployeeInfos
					.FirstOrDefaultAsync(c => c.EmployeeId == employeeRequest.EmployeeId);

			employeeInfo.Passport = employeeRequest.Passport;
			employeeInfo.Snils = employeeRequest.Snils;
			employeeInfo.Name = employeeRequest.Name;
			employeeInfo.Lastname = employeeRequest.Lastname;
			employeeInfo.Surname = employeeRequest.Surname;

			await _companyRegisterDbContext.SaveChangesAsync();
		}

		public async Task DeleteEmployeeAsync(int employeeId)
		{
			var employeeInfos = await _companyRegisterDbContext
					.EmployeeInfos
					.FirstOrDefaultAsync(c => c.EmployeeId == employeeId);

			if (employeeInfos != null)
			{
				_companyRegisterDbContext
					.EmployeeInfos
					.Remove(employeeInfos);

				await _companyRegisterDbContext.SaveChangesAsync();
			}

			var employee = await _companyRegisterDbContext
					.Employees
					.FirstOrDefaultAsync(c => c.Id == employeeId);

			if (employee == null)
			{
				return;
			}

			_companyRegisterDbContext
					.Employees
					.Remove(employee);

			await _companyRegisterDbContext.SaveChangesAsync();
		}
	}
}