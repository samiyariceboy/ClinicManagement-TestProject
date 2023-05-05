using ClinicManagement.Entities.AggregateRoots.UserAggregateRoot.Entities;
using ClinicManagement.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace ClinicManagement.Entities.Identity
{
    public class Role : IdentityRole<Guid>, IEntity
    {
        #region Ctors
        private Role(){}
        public Role(string roleName)
        {
            Name = roleName;
            NormalizedName = roleName.ToUpper();
        }
        #endregion

        #region Properties
        #endregion

        #region Relation
        #region ForeignKey

        #endregion

        #region ICollaction
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
        #endregion
    }
}
