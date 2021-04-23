namespace ObserverAPI.Models.InputModels
{
    public class AddVeiculoInputModel
    {
        public string Nome { get; set; }
        public string Modelo { get; set; }

        public AddVeiculoInputModel(string nome, string modelo)
        {
            Nome = nome;
            Modelo = modelo;
        }
    }
}