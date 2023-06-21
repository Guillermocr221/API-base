namespace APIMongoDBC_.Models
{
    public class VehiclesSettings : IVehiclesSettings
    {
        public string Collection { get ; set; } = String.Empty;
        public string Database { get ; set ; } = String.Empty;
        public string Connection { get; set; } = String.Empty;
    }
}
