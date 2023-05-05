using ClinicManagement.Entities.Common;
namespace ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot.Entities
{
    /// <summary>
    /// اقساط پرداختی که توسط بیمار و یا شرکت بیمه پرداخت میشود
    /// </summary>
    public class PaymentInstallments : BaseEntity
    {
        #region Ctors

        #endregion

        #region Propeties
        /// <summary>
        /// صورت حساب
        /// </summary>
        public Guid InvoiceId { get; private set; }
        /// <summary>
        /// شرکت بیمه پرداخت کننده
        /// </summary>
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
