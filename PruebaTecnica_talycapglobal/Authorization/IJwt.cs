using PruebaTecnica.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Authorization
{
    public interface IJwt
    {
        /// <summary>
        /// Funcion que obtiene el token con jwt
        /// </summary>
        /// <param name="user">Objeto user</param>
        /// <returns>string con token</returns>
        string GetToken(User user);
    }
}
