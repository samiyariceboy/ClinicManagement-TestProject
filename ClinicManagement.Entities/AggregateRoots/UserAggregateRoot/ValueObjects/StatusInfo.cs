
using ClinicManagement.Common.Utilities;
using ClinicManagement.Entities.Common;

namespace ClinicManagement.Entities.AggregateRoots.UserAggregateRoot.ValueObjects
{
    public class StatusInfo : BaseValueObject
    {
        #region Properties
        /// <summary>
        /// Explain: کاربر فعال است؟ 
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Explain: لیدر و یا سوپر ادمین
        /// </summary>
        public bool IsSuperAdmin { get; private set; }

        /// <summary>
        /// Explain: ثبت شده با کاربر پدر
        /// </summary>
        public Guid? ParentUserId { get; private set; }

        /// <summary>
        /// Explain: کد دعوت
        /// </summary>
        public string? InvitationCode { get; private set; }
        #endregion

        #region Ctors
        private StatusInfo() { }
        public StatusInfo(bool isActive)
        {
            IsActive = isActive;
        }
        public StatusInfo(bool isActive, bool isSuperAdmin) : this(isActive)
        {
            IsSuperAdmin = isSuperAdmin;
        }
        public StatusInfo(bool isActive, bool isSuperAdmin, Guid? parentUserId) : this(isActive, isSuperAdmin)
        {
            ParentUserId = parentUserId;
        }
        #endregion

        #region Methods
        #region Public
        public StatusInfo SetParentUser(Guid parentUserId)
            => new(IsActive, IsSuperAdmin, parentUserId);
        public StatusInfo Active()
            => new(true, IsSuperAdmin, ParentUserId ?? null);
        public StatusInfo DiActive()
            => new(false, IsSuperAdmin, ParentUserId);
        public StatusInfo ActiveOrDiActive()
            => new(!IsActive, IsSuperAdmin, ParentUserId);
        public StatusInfo EnableOrDisableSuperAdmin()
            => new(IsActive, !IsSuperAdmin, ParentUserId);
        public void GenerateInvitationCode(int countOfSubsetring = 7)
           => InvitationCode = SecurityHelper.GetFileGuid(countOfSubsetring);
        #endregion
        #region Private

        #endregion
        #endregion

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IsActive;
            yield return IsSuperAdmin;
            yield return ParentUserId;
            yield return InvitationCode;
        }
    }
}
