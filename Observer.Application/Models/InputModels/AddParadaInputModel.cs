namespace ObserverAPI.Models.InputModels
{
    public class AddParadaInputModel
    {
        public string Nome { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public AddParadaInputModel(string nome, double latitude, double longitude)
        {
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}