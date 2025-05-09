
using BusinessLogic;
using DataAccess.DAO;
using DataAccess.Repositories.Interface;
using DataAccess.Repositories;

namespace StudentNameMVC

{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<FunewsManagementContext>(configuration.GetConnectionString("DefaultString"));

            services.AddSingleton<SystemAccountDAO>();
            services.AddSingleton<NewsArticleDAO>();
            services.AddSingleton<CategoryDAO>();
            services.AddSingleton<TagDAO>();

            services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
            services.AddScoped<INewsArticleRepository, NewsArticleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            return services;
        }
    }
}
