namespace RiftEngine
{
    public class ConfigFileNotFoundException : Exception
    {
        public ConfigFileNotFoundException() { }
        public ConfigFileNotFoundException(string message) : base(message) { }
        public ConfigFileNotFoundException(string message, Exception inner) : base(message, inner) { }
    }

    public class FilePathInvalidException : Exception
    {
        public FilePathInvalidException() { }
        public FilePathInvalidException(string message) : base(message) { }
        public FilePathInvalidException(string message, Exception inner) : base(message, inner) { }
    }

    public class GameReferenceNullException : Exception
    {
        public GameReferenceNullException() { }
        public GameReferenceNullException(string message) : base(message) { }
        public GameReferenceNullException(string message, Exception inner) : base(message, inner) { }
    }

    public class GameAlreadyInitializedException : Exception
    {
        public GameAlreadyInitializedException() { }
        public GameAlreadyInitializedException(string message) : base(message) { }
        public GameAlreadyInitializedException(string message, Exception inner) : base(message, inner) { }
    }

    public class GameAlreadyRunningException : Exception
    {
        public GameAlreadyRunningException() { }
        public GameAlreadyRunningException(string message) : base(message) { }
        public GameAlreadyRunningException(string message, Exception inner) : base(message, inner) { }
    }

    public class GameNotRunningException : Exception
    {
        public GameNotRunningException() { }
        public GameNotRunningException(string message) : base(message) { }
        public GameNotRunningException(string message, Exception inner) : base(message, inner) { }
    }
}
