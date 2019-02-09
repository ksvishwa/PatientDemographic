using Moq;
using NUnit.Framework;
using PatientDemographicDetails.Repo;
using PatientDemographicDetails.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace PatientDemographicDetails.Api.Controllers.Tests
{
    [TestFixture]
    public class PatientsControllerTest
    {
        IPatientDemographicsRepository _PatientDemographicsRepository;
        PatientDetail patientDetail = null;
        [SetUp]        
        // This method is used to setup the data.
        public void Setup()
        {
            patientDetail = new PatientDetail() { ForeName = "Vishwa", SurName = "Reddy", Gender = "Male" };

            List<PatientDetail> lstPatient = new List<PatientDetail>();
            lstPatient.Add(new PatientDetail() { ForeName = "Vishwa", SurName = "Reddy", DateofBirth = DateTime.Now.AddDays(-20), Gender = "Male" });
            lstPatient.Add(new PatientDetail() { ForeName = "Aadit", SurName = "Reddy", DateofBirth = DateTime.Now.AddDays(-20), Gender = "Male" });
            PatientPagingModel patientPagingModel = new PatientPagingModel() { TotalRecords = 5, PatientDetails = lstPatient };

            ////Used MOQ framework to return predefined  data
            var PatientDemographicRepository = new Mock<IPatientDemographicsRepository>();
            PatientDemographicRepository.Setup(x => x.GetAllPatientDemographics(1, 4)).Returns(patientPagingModel);
            PatientDemographicRepository.Setup(x => x.PostPatientDetails(patientDetail)).Returns(true);
            _PatientDemographicsRepository = PatientDemographicRepository.Object;
        }

        [Test]
        //This test used to get patients by page number details
        public void GetValidPatient()
        {
            IHttpActionResult actionResult = new PatientsController(_PatientDemographicsRepository).Get(1, 4);
            var contentResult = actionResult as OkNegotiatedContentResult<PatientPagingModel>;

            Assert.IsNotNull(contentResult.Content.PatientDetails);
        }

        [Test]
        // This method is used to add a new patient
        public void PostPatientDetailSuccess()
        {
            IHttpActionResult actionResult = new PatientsController(_PatientDemographicsRepository).Post(patientDetail);
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsTrue(contentResult.Content);
        }
        [Test]
        //Fail test case for creating a patient
        public void PostPatientDetailFailed()
        {
            patientDetail = new PatientDetail() { ForeName = "Aadit", SurName = "S", Gender = "Male" };
            IHttpActionResult actionResult = new PatientsController(_PatientDemographicsRepository).Post(patientDetail);
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsFalse(contentResult.Content);
        }
        [Test]
        // This method is used to create patient with invalid request
        public void PostPatientDetailInvalidRequest()
        {
            patientDetail = null;

            HttpResponseException ex = Assert.Throws<HttpResponseException>(() => new PatientsController(_PatientDemographicsRepository).Post(patientDetail));

            Assert.That(ex.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}