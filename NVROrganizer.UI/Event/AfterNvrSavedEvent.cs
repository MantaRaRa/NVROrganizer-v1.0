using Prism.Events;

namespace NvrOrganizer.UI.Event
{
    public class AfterNvrSavedEvent:PubSubEvent<AfterNvrSavedEventArgs>
    {
    }

    public class AfterNvrSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
