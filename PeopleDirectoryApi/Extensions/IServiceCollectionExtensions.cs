using CompanyRegisterApi.Interfaces;
using CompanyRegisterApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeopleDirectoryApi.Interfaces;
using PeopleDirectoryApi.Services;
using PeopleDirectoryApi.Settings;
using System.Text.Json.Serialization;

namespace PeopleDirectoryApi.Extensions
{
    public static class IServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection services)
		{
			services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


			return services
				.AddTransient<ICompanyService, CompanyService>()
				.AddTransient<IEmployeeService, EmployeeService>();

		}

		public static IServiceCollection ConfigureDataBase(this IServiceCollection services, AppSettings appSettings)
		{
			return services
				.AddDbContext<CompanyRegisterDbContext>(options => options.UseSqlServer(appSettings.DataBaseSettings.ConnectionString));

		}
	}
}
