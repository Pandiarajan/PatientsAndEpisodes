using RestApi.Models;

namespace RestApi.UnitTests.App_Start
{
    public class TestInMemoryPatientContext : InMemoryPatientContext
    {
        public TestInMemoryPatientContext()
        {
            Loader.LoadPatients(this);
            Loader.LoadEpisode(this);
        }
    }
}
