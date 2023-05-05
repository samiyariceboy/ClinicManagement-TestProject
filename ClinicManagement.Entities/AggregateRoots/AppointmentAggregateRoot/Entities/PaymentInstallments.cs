using ClinicManagement.Entities.Common;
namespace ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot.Entities
{
    public class PaymentInstallments : BaseEntity
    {
        #region Ctors

        #endregion

        #region Propeties
        public Guid InvoiceId { get; private set; }
        public Guid? InsuranceCompanyId { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual Invoice Invoice { get; private set; }

        public virtual InsuranceCompanyAggregateRoot.
        InsuranceCompanyAggregateRoot? InsuranceCompany { get; private set; }
        #endregion
        #region ICollections

        #endregion
        #endregion

        #region Methods

        #endregion
    }
}
