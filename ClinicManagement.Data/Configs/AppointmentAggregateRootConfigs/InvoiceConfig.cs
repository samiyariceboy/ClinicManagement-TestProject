using ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configs.AppointmentAggregateRootConfigs
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(o => o.Appointment)
                .WithOne(o => o.Invoice)
                .HasForeignKey<Invoice>(f => f.AppointmentId);

            builder.HasMany(m => m.PaymentInstallments)
                .WithOne(o => o.Invoice);
        }
    }
}
