﻿namespace ObserverAPI.Entities
{
    public class Veiculo
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Modelo { get; private set; }
        public long LinhaId { get; private set; }
    }
}