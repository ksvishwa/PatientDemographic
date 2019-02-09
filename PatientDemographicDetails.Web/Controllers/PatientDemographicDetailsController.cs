using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDemographicDetails.Web.Controllers
{
    public class PatientDemographicDetailsController : Controller
    {
        public ActionResult Patients()
        {
            return View();
        }
    }
}