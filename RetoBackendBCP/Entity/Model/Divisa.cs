using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBackendBCP.Entity.Model
{
    public partial class Divisa
    {
        [Key]
        public int Id { get; set; }
        public string MonedaOrigen { get; set; } = null!;
        public string MonedaDestino { get; set; } = null!;
        public decimal TipoCambio { get; set; }
    }
}
