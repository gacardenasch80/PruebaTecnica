using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Authorization;
using PruebaTecnica.Service.Server.Interface;
using System.Threading.Tasks;

namespace PruebaTecnica.Controllers
{
    /// <summary>
    /// Controlador LoginController
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly IJwt _jwt;
        /// <summary>
        /// Controller constructor
        /// </summary>
        public LoginController(ILoginService service, IJwt jwt)
        {
            _service = service;
            _jwt = jwt;
        }
        /// <summary>
        /// Funcion encargada de realizar la validaciones de credenciales en el sistema
        /// </summary>
        /// <param name="userName">Nombre de usuarios</param>
        /// <param name="passWord">Password</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetLogin(string userName, string passWord)
        {
            var user = await _service.Login(userName, passWord);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(_jwt.GetToken(user));
        }
        /// <summary>
        /// Funcion que se encarga de devolver la cantidad de usuarios en el sistema
        /// </summary>
        /// <returns>Cantidad de usuarios</returns>
        [Authorize]
        [HttpGet("UsersCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetUsersCount()
        {
            var user = await _service.UsersCount();
            return Ok(user);
        }
    }
}
