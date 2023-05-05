﻿using Microsoft.EntityFrameworkCore;
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

            //builder.OwnsOne(f => f.UserInfo);
            builder.OwnsOne(f => f.StatusInfo);
            //builder.OwnsOne(f => f.ConfirmInfo);
            //builder.OwnsOne(f => f.SafeAndTimeInfo);

            builder.HasMany(f => f.UserRoles)
                .WithOne(b => b.User);


            /* builder.HasMany(f => f.SessionManagers)
                 .WithOne(b => b.User);*/
        }
    }
}
