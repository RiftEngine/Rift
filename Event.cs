namespace Rift.RiftEngine.Core
{
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
}
