namespace Rift.RiftEngine.Core
{
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
}
