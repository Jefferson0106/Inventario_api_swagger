using Javier_Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaPermisoController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public BusquedaPermisoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetUsuarios(int pagina, int cantidadPorPagina, string Nombre)
        {
            var Permiso = _dbcontext.Permisos.AsQueryable();
            if (!string.IsNullOrEmpty(Nombre))
            {
                Permiso = Permiso.Where(u => u.Nombre == Nombre);
            }
            if (!string.IsNullOrEmpty(Nombre))
            {
                Permiso = Permiso.Where(u => u.Nombre == Nombre);
            }

            var totalPaginas = (int)Math.Ceiling(Permiso.Count() / (double)cantidadPorPagina);

            var usuariosEnPagina = Permiso
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToList();

            return Ok(new { Usuarios = usuariosEnPagina, PaginaActual = pagina, TotalPaginas = totalPaginas });
        }
    }
}


