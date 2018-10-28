using System.Linq;
using System.Web.Http;
using RestApi.Interfaces;

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        public IDatabaseContext PatientContext { get; }

        public PatientsController(IDatabaseContext patientContext)
        {
            PatientContext = patientContext;
        }
        

        [HttpGet]
        public IHttpActionResult Get(int patientId)
        {            
            var patientsAndEpisodes =
                from p in PatientContext.Patients
                join e in PatientContext.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new {p, e};

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return Ok(first);
            }

            return NotFound();
        }
    }
}