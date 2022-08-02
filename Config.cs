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

        public Config(string name, bool useSave, string creatorID, string versionID, string creationDate)
        {
            Name = name;
            UseSave = useSave;
            CreatorID = creatorID;
            VersionID = versionID;
            CreationDate = creationDate;
        }
    }

    public class GameConfigManager
    {
        public static Config ReadGameConfiguration(string configFilePath)
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(configFilePath).Build();

                var section = config.GetSection(nameof(Config));
                var gameConfig = section.Get<Config>();
                return new Config(gameConfig.Name, gameConfig.UseSave, gameConfig.CreatorID, gameConfig.VersionID, gameConfig.CreationDate);
            }
            catch (Exception ex)
            {
                throw new ConfigFileNotFoundException($"The file path \"{configFilePath}\" was not a valid json file.", ex);
            }
        }
    }
}
