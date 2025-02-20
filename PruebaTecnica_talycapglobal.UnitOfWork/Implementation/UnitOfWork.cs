using PruebaTecnica.Repository.Implementation;
using PruebaTecnica.Repository.Interfaces;
using PruebaTecnica.UnitOfWork.Interface;

namespace PruebaTecnica.UnitOfWork.Implementation
{
    /// <summary>
    /// class UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Constructor de la UnitOfWork
        /// </summary>
        /// <param name="connectionString"></param>
        public UnitOfWork(string connectionString)
        {
            Factura = new FacturaRepository(connectionString);
        }
        public IFacturaRepository Factura { get; private set; }
    }
}
