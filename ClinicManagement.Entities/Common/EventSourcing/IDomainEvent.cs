using ClinicManagement.Entities.Common.EventSourcing.Domain;
using MediatR;

namespace ClinicManagement.Entities.Common.EventSourcing
{
    public interface IDomainEvent : INotification
    {
        public Event Event { get; }
    }
}
