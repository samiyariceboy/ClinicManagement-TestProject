using Microsoft.AspNetCore.Identity;
using ClinicManagement.Entities.Common;
using ClinicManagement.Entities.Identity;

namespace ClinicManagement.Entities.AggregateRoots.UserAggregateRoot.Entities;

public class UserRole : IdentityUserRole<Guid>, IEntity
{
    #region Ctors
    public UserRole() { }
    /// <summary>
    /// انتساب نقش به کاربران در سطح سیستم
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
        //ProjectId = Guid.Empty;
    }

    /// <summary>
    /// انتساب نقش به کاربران در سطح پروژه 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    public UserRole(Guid userId, Guid roleId, Guid projectId)
    {
        UserId = userId;
        RoleId = roleId;
        ProjectId = projectId;
    }
    #endregion

    #region Properties
    public virtual Guid Id { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public Guid? ProjectId { get; private set; }
    #endregion

    #region Relation
    #region ForeignKey
    public virtual UserAggregateRoot User { get; set; }
    public virtual Role Role { get; set; }
    #endregion

    #region ICollaction

    #endregion
    #endregion

    #region Mehtods
    public void ChangeUser(Guid userId)
    => UserId = userId;
    #endregion
}
