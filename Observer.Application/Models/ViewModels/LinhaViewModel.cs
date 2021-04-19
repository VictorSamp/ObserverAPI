using ObserverAPI.Entities;
using System.Collections.Generic;

namespace ObserverAPI.Models.ViewModels
{
    public class LinhaViewModel
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public List<Parada> Paradas { get; private set; }

        public LinhaViewModel(long id, string nome, List<Parada> paradas)
        {
            Id = id;
            Nome = nome;
            Paradas = paradas;
        }
    }
}