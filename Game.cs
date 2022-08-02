namespace Rift.RiftEngine.Core
{
    public class Game
    {
        readonly Config config;
        List<Interaction> interactions = new List<Interaction>();
        public List<Interaction> Interactions { get { return interactions; } }
        public Game(Config configuration)
        {
            config = configuration;
        }

        public static void SetTitle(string title)
        {
            Console.Title = title;
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
}
