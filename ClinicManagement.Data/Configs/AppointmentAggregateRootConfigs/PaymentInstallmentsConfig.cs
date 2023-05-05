using ClinicManagement.Entities.AggregateRoots.AppointmentAggregateRoot.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configs.AppointmentAggregateRootConfigs
{
    public class PaymentInstallmentsConfig : IEntityTypeConfiguration<PaymentInstallments>
    {
        public void Configure(EntityTypeBuilder<PaymentInstallments> builder)
        {
            builder.HasOne(o => o.Invoice)
                .WithMany(m => m.PaymentInstallments)
                .HasForeignKey(f => f.InvoiceId);
        }
    }
}
