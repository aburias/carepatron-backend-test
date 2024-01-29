using domain.Clients;

namespace infrastructure.Persistence
{
    public class DataSeeder
    {
        private readonly DataContext dataContext;

        public DataSeeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Seed()
        {
            var client = new Client("xosiosiosdhad", "John", "Smith", "john@gmail.com", "+18202820232");

            dataContext.Add(client);
            dataContext.SaveChanges();
        }
    }
}

