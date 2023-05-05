namespace ClinicManagement.Common.Settings
{
    public class SiteSettings
    {
        public ServicesHostDomainSetting servicesHostDomainSetting { get; set; }
        public string[] AllowCors { get; set; }
    }

    #region DomainSetting
    public class ServicesHostDomainSetting
    {
        public DomainSetting ProjectManagerService { get; set; }

        public class DomainSetting
        {
            public string SiteDomin { get; set; }
            public string LocalHostDomain { get; set; }
        }
    }
    #endregion

    #region DefaultFormInternalLimitationValues
    public class DefaultFormInternalLimitationValue
    {
        public int DefaultClountOfFormItemCanBeCreateInFormPage { get; set; }
        public int DefaultClountOfFormItemOptionCorrectAnswerCanBeCreate { get; set; }
    }
    #endregion
}
