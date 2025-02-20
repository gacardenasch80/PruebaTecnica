using PruebaTecnica.Data.Model;
using PruebaTecnica.Service.Server.Interface;
using PruebaTecnica.UnitOfWork.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Service.Server.Implementation
{
    /// <summary>
    /// class FacturaService
    /// </summary>
    public class FacturaService : IFacturaService
    {
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor de la clase FacturaService
        /// </summary>
        /// <param name="unitOfWork"></param>
        public FacturaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Function to create a new Factura
        /// </summary>
        /// <param name="Factura">Factura object with the information</param>
        /// <returns>New Factura identifier</returns>
        public async Task<int> FacturaCreate(Factura factura)
        {
            var id = await Task.FromResult(_unitOfWork.Factura.Insert(factura));
            return id;
        }

        /// <summary>
        /// Function to update a Factura
        /// </summary>
        /// <param name="Factura">Factura object with the information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        public async Task<bool> FacturaUpdate(Factura factura)
        {
            var response = false;
            // Get Factura by id
            var facturaToUpdate = _unitOfWork.Factura.GetById(factura.Id);
            // Check if FacturaToUpdate is not null
            if (facturaToUpdate != null)
            {
                facturaToUpdate.NumeroFactura = factura.NumeroFactura;
                facturaToUpdate.NumeroDocumento = factura.NumeroDocumento;
                facturaToUpdate.Nombre = factura.Nombre;
                facturaToUpdate.Monto = factura.Monto;
                response = await Task.FromResult(_unitOfWork.Factura.Update(facturaToUpdate));
            }
            // Return response
            return response;
        }
        /// <summary>
        /// Function to delete a Factura
        /// </summary>
        /// <param name="id">Factura identifier to delete</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        public async Task<bool> FacturaDelete(int id)
        {
            // Get Factura by id
            var facturaToDelete = _unitOfWork.Factura.GetById(id);
            // Check if ToDelete is not null
            if (facturaToDelete != null)
            {
                return await Task.FromResult(_unitOfWork.Factura.Delete(facturaToDelete));
            }
            return false;
        }
        /// <summary>
        /// Function to get all Facturas
        /// </summary>
        /// <returns>Factura list</returns>
        public async Task<List<Factura>> FacturaGet()
        {
            var facturas = await Task.FromResult(_unitOfWork.Factura.Get());
            return facturas.ToList();
        }
        /// <summary>
        /// Function to get a Factura by id
        /// </summary>
        /// <param name="id">Factura identifier</param>
        /// <returns>Factura object</returns>
        public async Task<Factura> FacturaGetById(int id)
        {
            var factura = await Task.FromResult(_unitOfWork.Factura.GetById(id));
            return factura;
        }
    }
}
