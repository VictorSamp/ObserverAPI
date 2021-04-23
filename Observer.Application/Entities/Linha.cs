using System.Collections.Generic;

namespace ObserverAPI.Entities
{
    public class Linha
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public ICollection<Parada> Paradas { get; private set; }

        public Linha(string nome)
        {
            Nome = nome;
        }

        public void UpdateLinha(string nome)
        {
            Nome = nome;
        }
    }
}