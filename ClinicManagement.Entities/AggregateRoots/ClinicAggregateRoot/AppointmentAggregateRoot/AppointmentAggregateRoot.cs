using ClinicManagement.Entities.Common;
using ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot.AppointmentAggregateRoot.Entities;

namespace ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot.AppointmentAggregateRoot;

public class AppointmentAggregateRoot : AggregateRoot
{
    #region Ctors

    #endregion

    #region Propeties
    /// <summary>
    /// کاربر با نقش بیمار
    /// </summary>
    public Guid UserId { get; set; }
    public Guid InvoiceId { get; set; }
    #endregion

    #region Relations
    #region ForeignKey
    public virtual Invoice Invoice { get; private set; }
    #endregion
    #region ICollections

    #endregion
    #endregion

    #region Methods

    #endregion

    #region Events

    #endregion
}
