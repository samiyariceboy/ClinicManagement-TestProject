using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicManagement.Entities.Identity;

namespace ClinicManagement.Data.Configs.IdentityConfig
{
    public class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            /*   builder.HasQueryFilter(filter => !filter.SafeAndTimeInfo.IsDelete);

               builder.OwnsOne(f => f.UserClaimInfo);
               builder.OwnsOne(f => f.SafeAndTimeInfo);*/
        }
    }
}
