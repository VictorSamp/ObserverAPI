namespace ObserverAPI.Entities
{
    public class Veiculo
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Modelo { get; private set; }
        public long LinhaId { get; private set; }

        public Veiculo(string nome, string modelo)
        {
            Nome = nome;
            Modelo = modelo;
        }

        public void UpdateVeiculo(string nome, string modelo)
        {
            Nome = nome;
            Modelo = modelo;
        }
    }
}