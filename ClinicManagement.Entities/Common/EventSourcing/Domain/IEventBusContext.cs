using ClinicManagement.Common.Settings;

namespace ClinicManagement.Entities.Common.EventSourcing.Domain
{
    public interface IEventBusContext
    {
        public SiteSettings SiteSettings { get; protected set; }
        string GetHosts();
    }
}
