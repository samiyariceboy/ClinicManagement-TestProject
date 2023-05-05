namespace ClinicManagement.Entities.Common
{
    public interface ICollactionEntity { }

    public abstract class BaseCollactionEntity<Tkey> : ICollactionEntity
    {
        protected BaseCollactionEntity()
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

    public abstract class BaseCollactionEntity : BaseCollactionEntity<Guid>
    {
        protected BaseCollactionEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}