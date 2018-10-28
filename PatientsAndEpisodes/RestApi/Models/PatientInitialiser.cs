namespace RestApi.Models
{
    public class PatientInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<PatientContext>
    {
        protected override void Seed(PatientContext context)
        {
            Loader.LoadPatients(context);
            context.SaveChanges();
            Loader.LoadEpisode(context);
            context.SaveChanges();
        }
    }
}