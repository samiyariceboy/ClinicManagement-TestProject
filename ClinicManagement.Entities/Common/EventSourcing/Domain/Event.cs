namespace ClinicManagement.Entities.Common.EventSourcing.Domain
{
    public interface IBaseQuestDto { }
    public class Event : BaseEvent
    {
        public Event(Guid streamId, string resource)
           : base(streamId, resource) { }

        public Event GetThisEvent() => this;
    }
}
