using PruebaTecnica.Data.Model;
using PruebaTecnica.Repository.Base;
using PruebaTecnica.Repository.Interfaces;

namespace PruebaTecnica.Repository.Implementation
{
    /// <summary>
    /// class FacturaRepository
    /// </summary>
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        /// <summary>
        /// /// Constructor del Repositorio de Factura
        /// </summary>
        /// <param name="connectionString"></param>
        public FacturaRepository(string connectionString) : base(connectionString) { }
    }
}
