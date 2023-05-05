using ClinicManagement.Entities.Common.EventSourcing;

namespace ClinicManagement.Entities.Common
{
    public interface IAggregateRoot : IEntity
    {
        void ClearDomainEvents();
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}