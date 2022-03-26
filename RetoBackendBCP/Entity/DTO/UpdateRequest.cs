namespace RetoBackendBCP.Entity.DTO
{
    public class UpdateRequest
    {
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; } 
        public decimal TipoCambio { get; set; }
    }
}
