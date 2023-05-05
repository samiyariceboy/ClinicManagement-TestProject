using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicManagement.Entities.AggregateRoots.UserAggregateRoot;

namespace ClinicManagement.Data.Configs.IdentityConfig
{
    public class UserConfig : IEntityTypeConfiguration<UserAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<UserAggregateRoot> builder)
        {
            //builder.HasQueryFilter(filter => !filter.SafeAndTimeInfo.IsDelete);

            builder.Property(f => f.UserName)
                .IsRequired().IsUnicode();

            builder.OwnsOne(f => f.StatusInfo);

            builder.HasMany(f => f.UserRoles)
                .WithOne(b => b.User);

            builder.HasMany(m => m.Appointments)
                .WithOne(o => o.PatientUser);

            builder.HasMany(m => m.InsuredPatientUsers)
               .WithOne(m => m.PatientUser);
        }
    }
}
