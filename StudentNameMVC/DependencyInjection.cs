using DataAccess;
using DataAccess.DAO;

using DataAccess.Repositories.Interface;
using DataAccess.Repositories;
using BusinessLogic;

namespace StudentNameMVC

{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<FunewsManagementContext>(configuration.GetConnectionString("DefaultString"));

            services.AddScoped<CategoryDAO>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
