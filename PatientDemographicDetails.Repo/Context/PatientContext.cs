using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
//using RestApi.Interfaces;

namespace PatientDemographicDetails.Repo.Models
{
    public class PatientContext : DbContext
    {

        public PatientContext() : base("PatientContext")
        {

        }

        public IDbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}