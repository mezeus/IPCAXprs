using QLicense;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DemoLicense
{
    public class MyLicense : QLicense.LicenseEntity
    {
        [DisplayName("Basic License")]
        [Category("License Options")]
        [XmlElement("BasicLicense")]
        [ShowInLicenseInfo(true, "Basic License", ShowInLicenseInfoAttribute.FormatType.String)]
        public bool BasicLicense { get; set; }

        [DisplayName("Standard License")]
        [Category("License Options")]
        [XmlElement("StandardLicense")]
        [ShowInLicenseInfo(true, "Stardard License", ShowInLicenseInfoAttribute.FormatType.String)]
        public bool StandardLicense { get; set; }

        [DisplayName("Enterprise License")]
        [Category("License Options")]
        [XmlElement("EnterpriseLicense")]
        [ShowInLicenseInfo(true, "Enterprise License", ShowInLicenseInfoAttribute.FormatType.String)]
        public bool EnterpriseLicense { get; set; }

        public override LicenseStatus DoExtraValidation(out string validationMsg)
        {
            //Here, there is no extra validation, just return license is valid
            validationMsg = string.Empty;
            return LicenseStatus.VALID;
        }
    }
}
