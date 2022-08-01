using Microsoft.Extensions.Configuration;

namespace RiftEngine
{
    public static class Engine
    {
        public static Game? gameReference;

        public static bool isInitialized = false;

        public static bool isStarted = false;

        public static void SetGameReference(Game reference)
        {
            gameReference = reference;
        }

        public static void Init()
        {
            if (!isInitialized)
            {
                isInitialized = true;
            }
            else
            {
                throw new GameAlreadyInitializedException("The game was already initialized.");
            }
            if (gameReference != null)
            {
                gameReference.Init();
            } else
            {
                throw new GameReferenceNullException("The game reference is null.");
            }
        }

        public static void Start()
        {
            if (!isStarted)
            {
                isStarted = true;
            } else
            {
                throw new GameAlreadyRunningException("The game is already running.");
            }
            if (gameReference != null)
            {
                gameReference.Init();
            }
            else
            {
                throw new GameReferenceNullException("The game reference is null.");
            }
            Events.GameStart.Trigger();
        }

        public static void Stop()
        {
            if (isStarted)
            {
                isStarted = false;
            } else
            {
                throw new GameNotRunningException("The game is not running.");
            }
            if (gameReference != null)
            {
                gameReference.Stop();
            } else
            {
                throw new GameReferenceNullException("The game reference was null.");
            }
            Events.GameStop.Trigger();
        }
    }
    public class Game
    {
        readonly Config config;
        List<Interaction> interactions = new List<Interaction>();
        public List<Interaction> Interactions { get { return interactions; } }
        public Game(Config configuration)
        {
            config = configuration;
        }

        public void AddInteraction(Interaction interaction)
        {
            interactions.Add(interaction);
        }

        /// <summary>
        /// Runs once before the game starts
        /// </summary>
        public virtual void Init()
        {

        }

        /// <summary>
        /// Runs once when the game starts
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Runs continuously from the start of the game to the end
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// Runs once when the game stops
        /// </summary>
        public virtual void Stop()
        {

        }
    }

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
                return gameConfig;
            }
            catch (Exception ex)
            {
                throw new ConfigFileNotFoundException($"The file path \"{configFilePath}\" was not a valid json file.", ex);
            }
        }
    }

    public class Interaction
    {
        public readonly string InteractionName;
        public readonly Event trigger;
        public readonly string output;
        public Interaction(string interactionName, Event trigger, string output)
        {
            InteractionName = interactionName;
            this.trigger = trigger;
            this.output = output;
        }

        public Interaction(string interactionName, Event trigger, FilePath output)
        {
            InteractionName = interactionName;
            this.trigger = trigger;
            try
            {
                this.output = File.ReadAllText(output.ToString());
            }
            catch (Exception ex)
            {
                throw new FilePathInvalidException($"The file path \"{output.ToString()}\" was not a valid file.", ex);
            }
        }

        public void Trigger()
        {
            Console.WriteLine(output);
        }
    }

    public class Event
    {
        public Func<bool> checkConditions;

        public Event(Func<bool> checkConditions)
        {
            this.checkConditions = checkConditions;
        }

        public Event()
        {
            checkConditions = delegate ()
            {
                return false;
            };
        }

        public void CheckTrigger()
        {
            if (checkConditions() == true)
            {
                Trigger();
            }
        }

        public void Trigger()
        {
            if (Engine.gameReference != null)
            {
                foreach (Interaction i in Engine.gameReference.Interactions)
                {
                    if (i.trigger == this)
                    {
                        i.Trigger();
                    }
                }
            } else
            {
                throw new GameReferenceNullException("The game reference is null.");
            }
        }
    }

    public static class Events
    {
        public static Event GameStart = new Event();

        public static Event GameStop = new Event();
    }

    public class FilePath
    {
        readonly string filePath;
        public FilePath(string filePath)
        {
            this.filePath = filePath;
        }

        public override string ToString()
        {
            return filePath;
        }
    }
}
