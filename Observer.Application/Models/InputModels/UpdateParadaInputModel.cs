namespace ObserverAPI.Models.InputModels
{
    public class UpdateParadaInputModel
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public UpdateParadaInputModel(long id, string nome, double latitude, double longitude)
        {
            Id = id;
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}