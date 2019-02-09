using PatientDemographicDetails.Repo;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PatientDemographicDetails.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IPatientDemographicsRepository, PatientDemographicRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}