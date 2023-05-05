using ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot.ValueObjects;
using ClinicManagement.Entities.Common;

namespace ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot
{
    public class ClinicAggregateRoot : AggregateRoot
    {
        public ClinicAggregateRoot(string clinicName, Address clinicAddress,
            DateTime dateTimeEstablishment)
        {
            ClinicName = clinicName;
            ClinicAddress = clinicAddress;
            DateTimeEstablishment = dateTimeEstablishment;
        }
        #region Ctors
        private ClinicAggregateRoot(){}
        #endregion

        #region Propeties
        public string ClinicName { get; private set; }
        public DateTime DateOfEstablishment { get; private set; }
        public Address ClinicAddress { get; private set; }
        public DateTime DateTimeEstablishment { get; }
        #endregion

        #region Relations
        #region ForeignKey
        #endregion
        #region ICollections

        #endregion
        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion
    }
}
