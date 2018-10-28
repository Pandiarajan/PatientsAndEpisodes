using NUnit.Framework;
using RestApi.Controllers;
using RestApi.Models;
using System.Linq;
using System.Web.Http.Results;
using Unity;

namespace RestApi.UnitTests
{
    [TestFixture]
    public class PatientsControllerTests
    {
        PatientsController patientsController;

        [SetUp]
        public void SetUp()
        {
            patientsController = UnityConfig.Container.Resolve<PatientsController>();
        }

        [Test]
        public void ControllerGet_Returns_PatientWithEpisodes_WhenPatientIdPresent()
        {
            var patientResult = patientsController.Get(1) as OkNegotiatedContentResult<Patient>;
            var patient = patientResult.Content;
            Assert.AreEqual(patient.PatientId, 1, "PatientId mismatch");
            Assert.IsTrue(!string.IsNullOrEmpty(patient.NhsNumber), "Nhs number not present.");
            Assert.IsTrue(patient.Episodes.Any(), "No episodes found.");
        }

        [Test]
        public void ControllerGet_Returns_NotFound_WhenPatientNotPresent()
        {
            var result = patientsController.Get(55) as NotFoundResult;
            Assert.NotNull(result);
        }
    }
}
