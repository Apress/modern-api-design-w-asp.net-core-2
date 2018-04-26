using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AwesomeConfiguration
{
    public class AwesomeConfigurationProvider : ConfigurationProvider, IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }

        private readonly string fileName;
        public AwesomeConfigurationProvider(string fileName)
        {
            this.fileName = fileName;
        }
        public override void Load()
        {
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var doc = XDocument.Load(fs);
                var connectionStrings = doc.Root.Descendants()
                    .Where(e => e.Name.Equals(XName.Get("connectionStrings")))
                    .Descendants(XName.Get("add")).Select(e =>
                        new KeyValuePair<string, string>(
                            $"connectionStrings:{e.Attribute(XName.Get("name")).Value}",
                            e.Attribute(XName.Get("connectionString")).Value));

                var appSettings = doc.Root.Descendants()
                    .Where(e => e.Name.Equals(XName.Get("appSettings")))
                    .Descendants(XName.Get("add")).Select(e =>
                        new KeyValuePair<string, string>(
                            $"appSettings:{e.Attribute(XName.Get("key")).Value}",
                            e.Attribute(XName.Get("value")).Value));

                Data = connectionStrings.Union(appSettings).ToDictionary(e => e.
                Key, e => e.Value);
            }
        }
    }
}
