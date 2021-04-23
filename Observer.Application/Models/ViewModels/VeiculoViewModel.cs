namespace ObserverAPI.Models.ViewModels
{
    public class VeiculoViewModel
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Modelo { get; private set; }
        public long? LinhaId { get; private set; }

        public VeiculoViewModel(long id, string nome, string modelo, long? linhaId)
        {
            Id = id;
            Nome = nome;
            Modelo = modelo;
            LinhaId = null;
        }
    }
}