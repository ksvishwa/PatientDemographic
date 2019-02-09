
using PatientDemographicDetails.Repo.Helper;
using PatientDemographicDetails.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientDemographicDetails.Repo
{
    public class PatientDemographicRepository : IPatientDemographicsRepository
    {
        //Returns all the Patient details with paging
        public PatientPagingModel GetAllPatientDemographics(int currentPage, int recordsPerPage)
        {
            PatientPagingModel patientViewModel = new PatientPagingModel();
            List<PatientDetail> lstPatient  = new List<PatientDetail>();

            int skipRecords = (currentPage -1 ) * (recordsPerPage);
            try
            {
                var patientContext = new PatientContext();

                var response = from patients in patientContext.Patients
                               orderby patients.PatientId
                               select new { X = patients };


                //To retrieve the total number of records found
                patientViewModel.TotalRecords = response.Count();

                //Pagination support
                var responseData = response.Skip(skipRecords).Take(recordsPerPage);

                foreach (var item in responseData)
                {
                    //Deserialize XML to object using extension method
                    PatientDetail patientDetail = item.X.PatientDetail.Deserialize<PatientDetail>();
                    lstPatient.Add(patientDetail);
                }
                patientViewModel.PatientDetails = lstPatient;

                return patientViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Inserts the PatientDetail to the Database
        public bool PostPatientDetails(PatientDetail patientViewModel)
        {
            try
            {
                using (var ctx = new PatientContext())
                {
                    Patient patient = new Patient();
                    //Deserialize Object to XML
                    patient.PatientDetail = Serializer.Serialize<PatientDetail>(patientViewModel); ;
                    ctx.Patients.Add(patient);
                    ctx.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}