using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientDemographicDetails.Repo.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [Column(TypeName = "xml")]
        public string PatientDetail { get; set; }
    }
}