using Javier_Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaTipoProductoController : ControllerBase
    {

        public readonly dbProyecto_InventarioContext _dbcontext;

        public BusquedaTipoProductoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetUsuarios(int pagina, int cantidadPorPagina, string Nombre)
        {
            var TipoProducto = _dbcontext.TipoProductos.AsQueryable();
            if (!string.IsNullOrEmpty(Nombre))
            {
                TipoProducto = TipoProducto.Where(u => u.Nombre == Nombre);
            }
            if (!string.IsNullOrEmpty(Nombre))
            {
                TipoProducto = TipoProducto.Where(u => u.Nombre == Nombre);
            }

            var totalPaginas = (int)Math.Ceiling(TipoProducto.Count() / (double)cantidadPorPagina);

            var usuariosEnPagina = TipoProducto
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToList();

            return Ok(new { Usuarios = usuariosEnPagina, PaginaActual = pagina, TotalPaginas = totalPaginas });
        }
    }
}
    

