using Microsoft.AspNetCore.Identity;
using ClinicManagement.Entities.Common;
using System.Security.Claims;

namespace ClinicManagement.Entities.Identity;

public class UserClaim : IdentityUserClaim<Guid>, IEntity
{
    #region Ctors
    public UserClaim() { }
    public UserClaim(Guid userId, Claim claim)
    {
        UserId = userId;
        ClaimType = claim.Type;
        ClaimValue = claim.Value;
    }
    #endregion

    #region Properties
    //public ClaimInfo UserClaimInfo { get; private set; }
    #endregion

}
