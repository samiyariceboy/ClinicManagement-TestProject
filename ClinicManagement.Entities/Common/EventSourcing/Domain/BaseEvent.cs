namespace ClinicManagement.Entities.Common.EventSourcing.Domain
{
    public interface IEvent { }
    public abstract class BaseEvent : IEvent
    {
        protected BaseEvent(string resource)
        {
            Resource = resource;
            StreamId = Guid.NewGuid();
            OcurrendOn = DateTime.Now;
            EventId = Guid.NewGuid();
        }

        protected BaseEvent(Guid streamId, string resource)
        {
            Resource = resource;
            StreamId = streamId;
            OcurrendOn = DateTime.Now;
            EventId = Guid.NewGuid();
        }


        /// <summary>
        /// is the identifier of the aggregateroot 
        /// </summary>
        public string Resource { get; init; }
        public Guid StreamId { get; init; }
        /// <summary>
        /// is the the date on which the event occurred
        /// </summary>
        public DateTime OcurrendOn { get; init; }
        /// <summary>
        /// Raise Aggregate Version
        /// </summary>
        public long AggregateVersion { get; private set; }

        public Guid EventId { get; }

        public void BuildVersion(long aggregateVersion)
       => AggregateVersion = aggregateVersion;
    }
}
