using ClinicManagement.Entities.Common;
using ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot.Entities;

namespace ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot;

/// <summary>
/// قراره ملاقات
/// </summary>
public class AppointmentAggregateRoot : AggregateRoot
{
    #region Ctors

    #endregion

    #region Propeties
    /// <summary>
    /// کاربر با نقش بیمار
    /// </summary>
    public Guid PatientUserId { get; private set; }
    /// <summary>
    /// صورت حساب مورد نظر
    /// </summary>
    public Guid InvoiceId { get; private set; }
    #endregion

    #region Relations
    #region ForeignKey
    public virtual Invoice Invoice { get; private set; }
    public virtual UserAggregateRoot.UserAggregateRoot PatientUser { get; private set; }
    #endregion

    #region ICollections

    #endregion
    #endregion

    #region Methods

    #endregion

    #region Events

    #endregion
}
