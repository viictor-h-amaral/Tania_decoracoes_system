using Microsoft.Extensions.Configuration;
using System.IO;

namespace TaniaDecoracoes.Entities.Data
{
    public static class AppSettings
    {
        public static IConfigurationRoot Configuration { get; }

        static AppSettings()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
