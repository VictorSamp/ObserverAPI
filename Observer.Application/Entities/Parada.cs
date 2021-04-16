namespace ObserverAPI.Entities
{
    public class Parada
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Parada(string nome, double latitude, double longitude)
        {
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}