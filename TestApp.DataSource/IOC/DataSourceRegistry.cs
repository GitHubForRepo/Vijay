using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestApp.DataSource
{
    public static class DataSourceRegistry
    {
        public static string _filePath = string.Empty;
        public static void ConfigureDataSourceRegistry(this IServiceCollection services, string filePath)
        {
            services.AddSingleton<IFileStore, FileStore>();
            _filePath = filePath;
        }
    }
}
