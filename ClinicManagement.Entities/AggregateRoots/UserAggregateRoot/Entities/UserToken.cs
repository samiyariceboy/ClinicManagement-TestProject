using Microsoft.AspNetCore.Identity;
using ClinicManagement.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Entities.Identity
{
    public class UserToken : IdentityUserToken<Guid>, IEntity
    {
        #region Ctros
        public UserToken() { }
        public UserToken(Guid userId, TwoStepDynamicVerificationProvider sentralProvider, DateTime? expirationTime)
        {
            UserId = userId;
            SentralProvider = sentralProvider;
            ExpirationTime = expirationTime;
        }

        public UserToken(Guid userId, string name, string value, int amountOfAddMinutesExpirationValue = 0)
        {
            UserId = userId;
            Name = name;
            Value = value;
            ExpirationTime = ComputeExpirationTimeAfterPeriodOfTime(amountOfAddMinutesExpirationValue);
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public TwoStepDynamicVerificationProvider SentralProvider { get; private set; }
        public DateTime? ExpirationTime { get; private set; }
        #endregion

        #region  Methods

        #region Public Methods

        public void ChangeSentralProvider(TwoStepDynamicVerificationProvider sentralProvider)
            => SentralProvider = sentralProvider;
        public void ChangeName(string name)
            => Name = name;
        public void UpdateUserTokenValue(string value, int amountOfAddMinutesExpirationValue = 0)
        {
            Value = value;
            ExpirationTime = ComputeExpirationTimeAfterPeriodOfTime(amountOfAddMinutesExpirationValue);
        }

        public void ClearUserTokenValue()
        {
            Value = null;
        }
        public void ChangeLoginProvider(string loginProvider)
            => LoginProvider = loginProvider;

        #endregion
        #region Private Methods
        internal static DateTime ComputeExpirationTimeAfterPeriodOfTime(int amountOfAddMinutesExpirationValue)
            => (amountOfAddMinutesExpirationValue > 0) ?
                DateTime.Now.AddMinutes(amountOfAddMinutesExpirationValue) : default;
        #endregion
        #endregion
    }
    #region Enums
    public enum TwoStepDynamicVerificationProvider
    {
        [Display(Name = "SMS")]
        SMS,
        [Display(Name = "Email")]
        Email,
        [Display(Name = "QrCode")]
        QrCode,
        [Display(Name = "CloudPassword")]
        CloudPassword,
        [Display(Name = "PureStepLoginToken")]
        PureStepLoginToken,
        [Display(Name = "None")]
        None
    }
    #endregion
}
