using PatientDemographicDetails.Repo.Models;
using PatientDemographicDetails.Repo;
using PatientDemographicDetails.Repo.Helper;
using System;
using System.Net;
using System.Web.Http;

namespace PatientDemographicDetails.Api.Controllers
{
    public class PatientsController : ApiController
    {
        private IPatientDemographicsRepository _patientDemographicsRepository;
        
        //Repository object is inected using Unity Container
        public PatientsController(IPatientDemographicsRepository patientDemographicsRepository)
        {
            _patientDemographicsRepository = patientDemographicsRepository;
        }

        //Insert Patient details
        [HttpPost]
        public IHttpActionResult Post(PatientDetail patientDetail)
        {
            if (patientDetail == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            bool result = false;
            try
            {
                result = _patientDemographicsRepository.PostPatientDetails(patientDetail);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Ok(result);
        }

        //Returns the Patient details with paging
        [HttpGet]
        public IHttpActionResult Get(int currentPage, int recordsPerPage)
        {
            try
            {
               return Ok(_patientDemographicsRepository.GetAllPatientDemographics(currentPage, recordsPerPage));
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}