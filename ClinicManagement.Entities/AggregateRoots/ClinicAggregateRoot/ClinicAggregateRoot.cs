using ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot.ValueObjects;
using ClinicManagement.Entities.Common;

namespace ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot
{
    /// <summary>
    /// کلینیک درمان
    /// </summary>
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
        /// <summary>
        /// نام کلینیک
        /// </summary>
        public string ClinicName { get; private set; }
        public DateTime DateOfEstablishment { get; private set; }
        /// <summary>
        /// آدرس کلینیک
        /// </summary>
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
