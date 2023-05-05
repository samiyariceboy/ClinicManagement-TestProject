using ClinicManagement.Entities.Common;

namespace ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot.AppointmentAggregateRoot.Entities
{
    public class Invoice : BaseEntity
    {
        #region Ctors

        #endregion

        #region Propeties
        public Guid AppointmentId { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual AppointmentAggregateRoot Appointment { get; private set; }
        #endregion
        #region ICollections

        /// <summary>
        /// Payment Installments | لیست پرداخت های صورت حساب
        /// </summary>
        public ICollection<PaymentInstallments> PaymentInstallments { get; private set; }
        #endregion
        #endregion

        #region Methods

        #endregion
    }
}
