using Dapper.Contrib.Extensions;

namespace PruebaTecnica.Data.Model
{
    /// <summary>
    /// class Factura
    /// </summary>
    public class Factura
    {
        /// <summary>
        /// Id de la tabla Factura
        /// </summary>
        [ExplicitKey]
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public int Monto { get; set; }
    }
}
