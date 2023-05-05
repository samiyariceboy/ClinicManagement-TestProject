namespace ClinicManagement.Entities.Common.EventSourcing.Structure
{
    public interface IEventSourcing
    {
        /// <summary>
        /// is the  current version of the aggregate
        /// </summary>
        long Version { get; }
        /// <summary>
        /// is a function that should raise an concurrency exception if the provided version is not equals to the current version of the aggregate.
        /// </summary>
        /// <param name="expectedVersion">A version is expected</param>
        void ValidateVersion(long expectedVersion);
        /// <summary>
        ///  is a function that applies an event to the aggragate .
        /// </summary>
        /// <param name="event"></param>
        /// <param name="version"></param>
        void ApplyEvent(IDomainEvent @event, long version);
        /// <summary>
        ///  a function that lists the history of all the events (not yet persisted) of the aggregate
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDomainEvent> GetUnCommittedEvents();
        /// <summary>
        /// a function that clear the list of uncommitted events of the aggregate
        /// </summary>
        void ClearUnCommittedEvent();
    }
}
