using ClinicManagement.Entities.Common;
using ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot.Entities;

namespace ClinicManagement.Entities.AggregateRoots.InsuranceCompanyAggregateRoot;

public class InsuranceCompanyAggregateRoot : AggregateRoot
{
    #region Ctors
    private InsuranceCompanyAggregateRoot(){}
    #endregion

    #region Propeties
    public string NameOfCompany { get; private set; }

    #endregion

    #region Relations
    #region ForeignKey

    #endregion
    #region ICollections
    public virtual ICollection<PaymentInstallments> PaymentInstallments { get; init; }
    #endregion
    #endregion

    #region Methods

    #endregion

    #region Events

    #endregion
}
