namespace ObserverAPI.Models.InputModels
{
    public class UpdateVeiculoInputModel
    {
        public string Nome { get; private set; }
        public string Modelo { get; private set; }

        public UpdateVeiculoInputModel(string nome, string modelo)
        {
            Nome = nome;
            Modelo = modelo;
        }
    }
}