using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;
namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaRolController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public BusquedaRolController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetUsuarios(int pagina, int cantidadPorPagina, string NombreRol)
        {
            var Rol = _dbcontext.Roles.AsQueryable();
            if (!string.IsNullOrEmpty(NombreRol))
            {
                Rol = Rol.Where(u => u.NombreRol == NombreRol);
            }
            if (!string.IsNullOrEmpty(NombreRol))
            {
                Rol = Rol.Where(u => u.NombreRol == NombreRol);
            }

            var totalPaginas = (int)Math.Ceiling(Rol.Count() / (double)cantidadPorPagina);

            var usuariosEnPagina = Rol
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToList();

            return Ok(new { Usuarios = usuariosEnPagina, PaginaActual = pagina, TotalPaginas = totalPaginas });
        }
    }
}
