using PruebaTecnica.Repository.Interfaces;

namespace PruebaTecnica.UnitOfWork.Interface
{
    /// <summary>
    /// interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        IFacturaRepository Factura { get; }
    }
}
