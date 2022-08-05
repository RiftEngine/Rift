using System.Text;

namespace Rift.RiftEngine.Core
{
    public class Interaction
    {
        public readonly string InteractionName;
        public readonly Event trigger;
        public readonly string output;
        public readonly List<object> parameters = new();
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

        public Interaction(string interactionName, Event trigger, string output, List<object> parameters)
        {
            InteractionName = interactionName;
            this.trigger = trigger;
            this.output = output;
            foreach (object p in parameters)
            {
                AddParameter(p);
            }
        }

        public Interaction(string interactionName, Event trigger, FilePath output, List<object> parameters)
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
            foreach (object p in parameters)
            {
                AddParameter(p);
            }
        }

        public Interaction(string interactionName, Event trigger, string output, object parameter)
        {
            InteractionName = interactionName;
            this.trigger = trigger;
            this.output = output;
            AddParameter(parameter);
        }

        public Interaction(string interactionName, Event trigger, FilePath output, object parameter)
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
            AddParameter(parameter);
        }

        public void AddParameter(object parameter)
        {
            parameters.Add(parameter);
        }

        public List<object> GetParameters()
        {
            return parameters;
        }

        public void RemoveParameter(int index)
        {
            parameters.RemoveAt(index);
        }

        public void RemoveParameter(object parameter)
        {
            parameters.Remove(parameter);
        }

        public void Trigger()
        {
            Console.WriteLine(string.Format(output, parameters.ToArray()));
        }
    }
}
