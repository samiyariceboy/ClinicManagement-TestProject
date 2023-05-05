using ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configs.AppointmentAggregateRootConfigs
{
    public class AppointmentAggregateRootConfig : IEntityTypeConfiguration<AppointmentAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<AppointmentAggregateRoot> builder)
        {
            builder.HasOne(o => o.Invoice)
                .WithOne(o => o.Appointment)
                .HasForeignKey<AppointmentAggregateRoot>(f => f.InvoiceId);

            builder.HasOne(o => o.PatientUser)
                .WithMany(m => m.Appointments)
                .HasForeignKey(f => f.PatientUserId);
        }
    }
}
