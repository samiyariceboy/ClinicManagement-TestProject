namespace ClinicManagement.Entities.Common.EventSourcing.Domain
{
    public abstract class BaseServiceBusRepository<IEventContext, TProduceEvent, TConsumeEvent>
        where IEventContext : class, IEventBusContext
        where TProduceEvent : class, IEvent
        where TConsumeEvent : class

    {
        protected readonly IEventBusContext EventBusContext;

        protected BaseServiceBusRepository(IEventBusContext eventBusContext)
        {
            EventBusContext = eventBusContext;
        }

        public abstract Task<bool> PublishAsync(string queueOrTopic, TProduceEvent message, CancellationToken cancellationToken);
        public abstract IAsyncEnumerable<TConsumeEvent> ConsumeAsync(string queueOrTopic, CancellationToken cancellationToken);
    }
}
