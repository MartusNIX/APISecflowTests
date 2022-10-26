using Microsoft.Extensions.Configuration;

namespace APISecflowTests.Managers
{
    internal class ConfigManager
    {
        private const string ConfigFile = "config.json";

        protected IConfigurationRoot Config => new ConfigurationBuilder()
                                                        .AddJsonFile(ConfigFile)
                                                        .Build();
    }
}
