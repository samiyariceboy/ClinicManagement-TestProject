using ClinicManagement.Entities.Common.EventSourcing;
using System.Text.Json.Serialization;

namespace ClinicManagement.Entities.Common
{
    public abstract class AggregateRoot : BaseEntity, IAggregateRoot
    {
        protected AggregateRoot() : base()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        [JsonIgnore]
        private readonly List<IDomainEvent> _domainEvents;

        [JsonIgnore]
        public IReadOnlyList<IDomainEvent> DomainEvents
        {
            get { return _domainEvents; }
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            if (domainEvent == null)
                return;
            _domainEvents?.Add(domainEvent);
        }

        protected void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            if (domainEvent == null)
                return;
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents?.Clear();
    }
}
