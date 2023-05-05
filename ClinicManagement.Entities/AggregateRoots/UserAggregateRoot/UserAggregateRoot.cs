using ClinicManagement.Common.Utilities;
using ClinicManagement.Entities.AggregateRoots.InsuranceCompanyAggregateRoot.Entities;
using ClinicManagement.Entities.AggregateRoots.UserAggregateRoot.Entities;
using ClinicManagement.Entities.AggregateRoots.UserAggregateRoot.ValueObjects;
using ClinicManagement.Entities.Common;

namespace ClinicManagement.Entities.AggregateRoots.UserAggregateRoot;

public class UserAggregateRoot : IdentityUserAggregateRoot
{
    #region Ctros
    private UserAggregateRoot() { }
    public UserAggregateRoot(string userName, string phoneNumber, bool isActive = false)
    {
        UserName = userName;
        PhoneNumber = phoneNumber;
        IsActive = isActive;
        CreateDate = DateTimeExtentions.SystemNow();
        LastUpdateDate = DateTimeExtentions.SystemNow();
        StatusInfo = new StatusInfo(false, false, null);
    }
    #endregion

    #region Properties
    public StatusInfo StatusInfo { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    #endregion

    #region Relation
    #region ICollaction
    public virtual ICollection<UserRole> UserRoles { get; private set; }

    public virtual ICollection<AppointmentAggregateRoot. AppointmentAggregateRoot> 
         Appointments { get; init; }
    public virtual ICollection<InsuredPatientUsers> InsuredPatientUsers { get; private set; }

    #endregion
    #endregion

    #region Methods
    public void ActiveUser()
    {
        IsActive = true;
    }
    #endregion
}

#region Enums
public enum InternalStaticRole
{
    HoldingAdmin,
    CompanyAdmin,
    Supervisor
}
#endregion
