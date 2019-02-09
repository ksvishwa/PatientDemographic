using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace PatientDemographicDetails.Repo.Models
{
    public class PatientDetail
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ForeName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string SurName { get; set; }

        private DateTime? dob;
        [XmlIgnore]

        public DateTime? DateofBirth
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
            }
        }

        [XmlElement("DateofBirth")]
        public string DoBstring
        {
            get
            {
                return DateofBirth.HasValue
                ? XmlConvert.ToString(DateofBirth.Value, XmlDateTimeSerializationMode.Unspecified)
                : string.Empty;
            }
            set
            {
                DateofBirth =
                !string.IsNullOrEmpty(value)
                ? XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Unspecified)
                : (DateTime?)null;
            }
        }

        [Required]
        public string Gender { get; set; }
        public PatientTelephoneNumber TelephoneNumbers { get; set; }
    }
}
