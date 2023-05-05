using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicManagement.Entities.AggregateRoots.InsuranceCompanyAggregateRoot.Entities;

namespace ClinicManagement.Data.Configs.InsuranceCompanyAggregateRootConfig
{
    public class InsuredPatientUsersConfig : IEntityTypeConfiguration<InsuredPatientUsers>
    {
        public void Configure(EntityTypeBuilder<InsuredPatientUsers> builder)
        {
            builder.HasOne(o => o.PatientUser)
                .WithMany(m => m.InsuredPatientUsers)
                .HasForeignKey(f => f.PatientUserId);

            builder.HasOne(o => o.InsuranceCompany)
                .WithMany(m => m.InsuredPatientUsers)
                .HasForeignKey(f => f.InsuranceCompanyId);
        }
    }
}
