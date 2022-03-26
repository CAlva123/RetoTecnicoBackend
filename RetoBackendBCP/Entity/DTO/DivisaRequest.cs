using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBackendBCP.Entity.DTO
{
    public class DivisaRequest
    {
        public decimal MontoInicial { get; set; }
        public string MonedaOrigen { get; set; } = null!;
        public string MonedaDestino { get; set; } = null!;
    }
}
