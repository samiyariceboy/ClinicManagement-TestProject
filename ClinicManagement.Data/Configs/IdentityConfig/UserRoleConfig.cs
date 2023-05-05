using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicManagement.Entities.Identity;

namespace ClinicManagement.Data.Configs.IdentityConfig
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            /* builder.HasQueryFilter(filter => !filter.SafeAndTimeInfo.IsDelete);

             builder.OwnsOne(f => f.SafeAndTimeInfo);*/
            builder.Property(f => f.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.HasKey(f => new { f.Id, f.UserId, f.RoleId });

            builder.HasOne(f => f.Role)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(H => H.RoleId);

            builder.HasOne(f => f.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(H => H.UserId);
        }
    }
}
