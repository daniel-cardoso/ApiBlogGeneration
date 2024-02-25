using ApiGenerationBlog.Repository;
using ApiGenerationBlog.Repository.Interfaces;
using ApiGenerationBlog.Services;
using ApiGenerationBlog.Services.Interfaces;

namespace ApiGenerationBlog.Extensions
{
    public static class DependencyConfiguration
    {
        public static void ConfigureServicesDependecies(IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IThemeService, ThemeService>();
        }

        public static void ConfigureRepositoriesDependencies(IServiceCollection repositories)
        {
            repositories.AddScoped<IUserRepository, UserRepository>();
            repositories.AddScoped<IPostRepository, PostRepository>();
            repositories.AddScoped<IThemeRepository, ThemeRepository>();
        }
    }
}
