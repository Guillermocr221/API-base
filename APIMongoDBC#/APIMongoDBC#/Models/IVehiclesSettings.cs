namespace APIMongoDBC_.Models
{
    public interface IVehiclesSettings
    {
        public string Collection { get; set; }
        public string Database { get; set; }
        public string Connection { get; set; }
    }
}
