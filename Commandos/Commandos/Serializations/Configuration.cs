using Microsoft.Extensions.Configuration;

namespace Commandos.Serialize
{
    public class Configuration
    {
        public IConfiguration AppConfiguration { get; }
        private static Configuration _configurationInstance;
        private Configuration(IConfigurationBuilder configurationBuilder)
        {
            AppConfiguration = configurationBuilder.Build();
        }
        public static Configuration GetInstance(IConfigurationBuilder configurationBuilder = null)
        {
            if (_configurationInstance == null)
            {
                if (configurationBuilder == null)
                {
                    throw new ArgumentNullException("Configuration builder should not be null!");
                }
                _configurationInstance = new Configuration(configurationBuilder);
            }
            return _configurationInstance;
        }
    }
}
