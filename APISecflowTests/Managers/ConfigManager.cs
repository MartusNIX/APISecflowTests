using Microsoft.Extensions.Configuration;

namespace APISecflowTests.Managers
{
    public class ConfigManager
    {
        private const string ConfigFile = "config.json";

        protected IConfigurationRoot Config => new ConfigurationBuilder()
                                                        .AddJsonFile(ConfigFile)
                                                        .Build();
    }
}
