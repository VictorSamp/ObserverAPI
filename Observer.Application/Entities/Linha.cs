using System.Collections.Generic;

namespace ObserverAPI.Entities
{
    public class Linha
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public List<Parada> Paradas { get; private set; }

        public Linha(string nome)
        {
            Nome = nome;
            Paradas = new List<Parada>();
        }

        public void UpdateLinha(string nome)
        {
            Nome = nome;
        }
    }
}