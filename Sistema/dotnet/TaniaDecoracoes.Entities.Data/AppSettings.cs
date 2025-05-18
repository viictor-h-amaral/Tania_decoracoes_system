using Microsoft.Extensions.Configuration;

namespace TaniaDecoracoes.Entities.Data
{
    public static class AppSettings
    {
        public static IConfigurationRoot Configuration { get; }

        static AppSettings()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
