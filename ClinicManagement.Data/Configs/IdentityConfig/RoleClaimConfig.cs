using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicManagement.Entities.Identity;

namespace ClinicManagement.Data.Configs.IdentityConfig
{
    public class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            /*builder.HasQueryFilter(filter => !filter.SafeAndTimeInfo.IsDelete);

            builder.OwnsOne(f => f.RoleClaimInfo);
            builder.OwnsOne(f => f.SafeAndTimeInfo);*/
        }
    }
}
