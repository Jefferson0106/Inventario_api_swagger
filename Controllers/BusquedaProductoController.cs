using Javier_Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaProductoController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public BusquedaProductoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetUsuarios(int pagina, int cantidadPorPagina, string NombreProducto)
        {
            var Producto = _dbcontext.Productos.AsQueryable();
            if (!string.IsNullOrEmpty(NombreProducto))
            {
                Producto = Producto.Where(u => u.NombreProducto == NombreProducto);
            }
            if (!string.IsNullOrEmpty(NombreProducto))
            {
                Producto = Producto.Where(u => u.NombreProducto == NombreProducto);
            }

            var totalPaginas = (int)Math.Ceiling(Producto.Count() / (double)cantidadPorPagina);

            var ProductosEnPagina = Producto
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToList();

            return Ok(new { Usuarios = ProductosEnPagina, PaginaActual = pagina, TotalPaginas = totalPaginas });
        }
    }
}
    

