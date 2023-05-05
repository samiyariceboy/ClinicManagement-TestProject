using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicManagement.Entities.Identity;

namespace ClinicManagement.Data.Configs.IdentityConfig
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            /*builder.HasQueryFilter(filter => !filter.SafeAndTimeInfo.IsDelete);

            builder.Property(f => f.Name).IsRequired().IsUnicode();
            builder.OwnsOne(f => f.RoleInfo);
            builder.OwnsOne(f => f.RoleCreator);
            builder.OwnsOne(f => f.SafeAndTimeInfo);*/

            builder.HasMany(f => f.UserRoles)
                .WithOne(b => b.Role);
        }
    }
}
