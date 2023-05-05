namespace ClinicManagement.Entities.Common.EventSourcing.Domain
{
    public interface IServiceBusRepository<TEvent> where TEvent : class, IEvent
    {
        IAsyncEnumerable<string> ConsumeAsync(string queueOrTopic, CancellationToken cancellationToken);
        Task<bool> PublishAsync(string queueOrTopic, TEvent @event, CancellationToken cancellationToken);
    }

    public interface IServiceBusRepository
        : IServiceBusRepository<Event>
    {
    }
}