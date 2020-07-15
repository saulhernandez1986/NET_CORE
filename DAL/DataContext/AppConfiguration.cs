using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        public string SqlConnectionStrings { get; set; }

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:cn");
            SqlConnectionStrings = appSetting.Value;
        }
        

    }
}
