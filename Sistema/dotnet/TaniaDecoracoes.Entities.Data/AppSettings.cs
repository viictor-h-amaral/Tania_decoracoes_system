using Microsoft.Extensions.Configuration;

namespace TaniaDecoracoes.Entities.Data
{
    public static class AppSettings
    {
        public static IConfigurationRoot Configuration { get; }

        static AppSettings()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath("C:\\Desenvolvimento\\TaniaDecoracoes_System\\Projeto\\Sistema\\dotnet\\TaniaDecoracoes.Entities.Data")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
