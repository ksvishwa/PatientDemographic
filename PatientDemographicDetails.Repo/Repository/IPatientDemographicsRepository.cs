using PatientDemographicDetails.Repo.Models;

namespace PatientDemographicDetails.Repo
{
    public interface IPatientDemographicsRepository
    {
        PatientPagingModel GetAllPatientDemographics(int currentPage, int recordsPerPage);
        bool PostPatientDetails(PatientDetail patientViewModel);
    }
}
