namespace Rift.RiftEngine.Core
{
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
