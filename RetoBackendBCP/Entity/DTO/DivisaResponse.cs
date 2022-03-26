using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBackendBCP.Entity.DTO
{
    public class DivisaResponse
    {
        public decimal MontoInicial { get; set; }
        public string MontoFinal { get; set; }
        public string MonedaOrigen { get; set; } = null!;
        public string MonedaDestino { get; set; } = null!;
        public decimal TipoCambio { get; set; }
        
    }
}
