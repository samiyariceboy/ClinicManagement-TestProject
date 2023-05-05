namespace ClinicManagement.Entities.Common
{
    public interface IEntity { }
    public abstract class BaseEntity<Tkey> : IEntity
    {
        protected BaseEntity()
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }

        public Tkey Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; init; }
        public DateTime LastUpdateDate { get; private set; }

        public void UpdateLastUpdateDate()
          => LastUpdateDate = DateTime.Now;
    }

    public abstract class BaseEntity : BaseEntity<Guid> { }
}
