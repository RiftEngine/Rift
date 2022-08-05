using Microsoft.Extensions.Configuration;

namespace Rift.RiftEngine.Core
{
    public class Config
    {
        public string Name { get; set; }
        public bool UseSave { get; set; }
        public string CreatorID { get; set; }
        public string VersionID { get; set; }
        public string CreationDate { get; set; }

        public static Config ReadGameConfiguration(string configFilePath)
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(configFilePath).Build();

                var section = config.GetSection(nameof(Config));
                var gameConfig = section.Get<Config>();
                return gameConfig;
            }
            catch (Exception ex)
            {
                throw new ConfigFileNotFoundException($"The file path \"{configFilePath}\" was not a valid json file.", ex);
            }
        }
    }
}
