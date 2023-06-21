using APIMongoDBC_.Models;

namespace APIMongoDBC_.Services
{
    public interface IVehicleService
    {
        List<Automovil> Get();
        Automovil Get(string id);
        Automovil Create(Automovil automovil);
        void Update(string id, Automovil automovil);
        void Remove(string id);


    }
}
