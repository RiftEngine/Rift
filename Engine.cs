namespace Rift.RiftEngine.Core
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
}
