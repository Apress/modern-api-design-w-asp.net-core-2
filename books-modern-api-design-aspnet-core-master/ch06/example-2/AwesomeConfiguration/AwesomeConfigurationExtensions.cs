using Microsoft.Extensions.Configuration;

namespace AwesomeConfiguration
{
    public static class AwesomeConfigurationExtensions
    {
        public static IConfigurationBuilder AddLegacyXmlConfiguration(this IConfigurationBuilder configurationBuilder, string path)
        {
            return configurationBuilder.Add(new AwesomeConfigurationProvider(path));
        }
    }
}
