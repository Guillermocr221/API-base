using APIMongoDBC_.Models;
using MongoDB.Driver;

namespace APIMongoDBC_.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMongoCollection<Automovil> _automoviles;

        public VehicleService(IVehiclesSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Database);//se extrae del Json
            _automoviles = database.GetCollection<Automovil>(settings.Collection);
        }
        public Automovil Create(Automovil automovil)
        {
            _automoviles.InsertOne(automovil);
            return automovil;
        }

        public List<Automovil> Get()
        {
            return _automoviles.Find(automovil => true).ToList();
        }

        public Automovil Get(string id)
        {
            return _automoviles.Find(automovil => automovil.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _automoviles.DeleteOne(automovil => automovil.Id == id);
        }

        public void Update(string id, Automovil automovil)
        {
            _automoviles.ReplaceOne(automovil => automovil.Id == id, automovil);
        }
    }
}
