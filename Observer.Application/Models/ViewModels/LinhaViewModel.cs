using ObserverAPI.Entities;
using System.Collections.Generic;

namespace ObserverAPI.Models.ViewModels
{
    public class LinhaViewModel
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }

        public LinhaViewModel(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}