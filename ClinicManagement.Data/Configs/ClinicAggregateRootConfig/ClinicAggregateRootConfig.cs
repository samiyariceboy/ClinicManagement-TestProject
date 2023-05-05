using ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configs.ClinicAggregateRootConfig
{
    public class ClinicAggregateRootConfig : IEntityTypeConfiguration<ClinicAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<ClinicAggregateRoot> builder)
        {
            builder.OwnsOne(o => o.ClinicAddress, options => 
            {
                options.ToJson();
            });
        }
    }
}
