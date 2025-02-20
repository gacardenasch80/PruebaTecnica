using PruebaTecnica.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.Service.Server.Interface
{
    /// <summary>
    /// interface IFacturaService
    /// </summary>
    public interface IFacturaService
    {
        /// <summary>
        /// Function to get all Facturas
        /// </summary>
        /// <returns>Factura list</returns>
        Task<List<Factura>> FacturaGet();
        /// <summary>
        /// Function to get a Factura by id
        /// </summary>
        /// <param name="id">Factura identifier</param>
        /// <returns>Factura object</returns>
        Task<Factura> FacturaGetById(int id);
        /// <summary>
        /// Function to create a new Factura
        /// </summary>
        /// <param name="factura">Factura object with the information</param>
        /// <returns>New Factura identifier</returns>
        Task<int> FacturaCreate(Factura factura);
        /// <summary>
        /// Function to update a Factura
        /// </summary>
        /// <param name="factura">Factura object with the information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        Task<bool> FacturaUpdate(Factura factura);
        /// <summary>
        /// Function to delete a Factura
        /// </summary>
        /// <param name="id">Factura identifier to delete</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        Task<bool> FacturaDelete(int id);
    }
}
