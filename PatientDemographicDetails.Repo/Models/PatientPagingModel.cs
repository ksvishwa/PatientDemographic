using System.Collections.Generic;

namespace PatientDemographicDetails.Repo.Models
{
    public class PatientPagingModel
    {
        public int TotalRecords { get; set; }
        public IEnumerable<PatientDetail> PatientDetails { get; set; }
    }
}