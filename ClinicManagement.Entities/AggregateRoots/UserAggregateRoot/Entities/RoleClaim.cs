using ClinicManagement.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;

namespace ClinicManagement.Entities.AggregateRoots.UserAggregateRoot.Entities
{
    public class RoleClaim : IdentityRoleClaim<Guid>, IEntity
    {
        #region Ctors
        public RoleClaim() { }
        public RoleClaim(Guid roleId, string name, Claim claim)
        {
            RoleId = roleId;
            ClaimType = claim.Type;
            ClaimValue = claim.Value;
            Name = name;
        }

        #endregion
        #region Properties
        public string Name { get; private set; }
        #endregion
    }
}
