using ClinicManagement.Entities.Common;

namespace ClinicManagement.Entities.AggregateRoots.InsuranceCompanyAggregateRoot.Entities
{
    public class InsuredPatientUsers : BaseEntity
    {
        #region Ctors

        #endregion

        #region Propeties
        public Guid PatientUserId { get; private set; }
        public Guid InsuranceCompanyId { get; private set; }

        public DateTime InsuredFromDate { get; private set; }
        public DateTime InsuredToDate { get; private set; }
        #endregion

        #region Relations
        #region ForeignKey
        public virtual InsuranceCompanyAggregateRoot InsuranceCompany { get; private set; }
        public virtual UserAggregateRoot.UserAggregateRoot PatientUser { get; private set; }
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
