using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;
namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public LoginController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var Login = _dbcontext.Logins.Select(r => new
                {
                    r.IdUsuario,


                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " su peticion ha sido exitosa ", response = Login });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
    }
}