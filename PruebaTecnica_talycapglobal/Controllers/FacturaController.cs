using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Data.Model;
using PruebaTecnica.Service.Server.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.Controllers
{
    /// <summary>
    /// Controlador FacturasController
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    //[Authorize]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;

        /// <summary>
        /// Controller constructor
        /// </summary>
        public FacturaController(IFacturaService service)
        {
            _service = service;
        }
        /// <summary>
        /// Returns the complete list of Facturas in the database
        /// </summary>
        /// <returns>Factura list</returns>
        /// <response code="200">Returns the get item</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
        {
            var response = await _service.FacturaGet();
            return Ok(response);
        }
        /// <summary>
        /// Function to get a Factura by id
        /// </summary>
        /// <param name="id">Factura identifier</param>
        /// <returns>Factura object with the information</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Factura>> GetById(int id)
        {
            var response = await _service.FacturaGetById(id);
            if (response != null)
                return Ok(response);
            else
                return NotFound();
        }

        /// <summary>
        /// Function to create a new Factura
        /// </summary>
        /// <param name="Factura">Rol JSON object with all information</param>
        /// <returns>Expense type list</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Post(Factura Factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _service.FacturaCreate(Factura);
            return Ok(response);
        }

        /// <summary>
        /// Function to update a Factura
        /// </summary>
        /// <param name="Factura">Rol JSON object with all information to update</param>
        /// <returns>True if the update is correct; otherwise it is false</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="400">Model is not valid</response>
        /// <response code="404">Id not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Put(Factura Factura)
        {
            if (!ModelState.IsValid || Factura.Id <= 0)
            {
                return BadRequest();
            }
            if (await _service.FacturaUpdate(Factura))
                return Ok(true);
            else
                return NotFound();
        }
        /// <summary>
        /// Function to delete a Factura by id
        /// </summary>
        /// <param name="id">Factura by id</param>
        /// <returns>True if the deletion is correct; otherwise it is false</returns>
        /// <response code="200">Returns the get item</response>
        /// <response code="404">Id is not found</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (await _service.FacturaDelete(id))
                return Ok(true);
            else
                return NotFound();
        }
    }
}
