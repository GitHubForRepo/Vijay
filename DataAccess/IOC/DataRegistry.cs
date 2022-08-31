using Microsoft.Extensions.DependencyInjection;
using TestApp.DataSource;

namespace TestApp.Data
{
    public static class DataRegistry
    {
        public static void ConfigureDataRegistry(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }
    }
}
