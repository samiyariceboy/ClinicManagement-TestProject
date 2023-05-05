using ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot.Entities;
using ClinicManagement.Entities.AggregateRoots.InsuranceCompanyAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configs.InsuranceCompanyAggregateRootConfig
{
    public class InsuranceCompanyAggregateRootConfig : IEntityTypeConfiguration<InsuranceCompanyAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<InsuranceCompanyAggregateRoot> builder)
        {
            builder.HasMany(m => m.InsuredPatientUsers)
                .WithOne(m => m.InsuranceCompany);
        }
    }
}
