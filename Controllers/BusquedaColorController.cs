using Javier_Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaColorController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public BusquedaColorController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetUsuarios(int pagina, int cantidadPorPagina, string Nombre)
        {
            var Color = _dbcontext.Colores.AsQueryable();
            if (!string.IsNullOrEmpty(Nombre))
            {
                Color = Color.Where(u => u.Nombre == Nombre);
            }
            if (!string.IsNullOrEmpty(Nombre))
            {
                Color = Color.Where(u => u.Nombre == Nombre);
            }

            var totalPaginas = (int)Math.Ceiling(Color.Count() / (double)cantidadPorPagina);

            var ColoresEnPagina = Color
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToList();

            return Ok(new { Color = ColoresEnPagina, PaginaActual = pagina, TotalPaginas = totalPaginas });
        }
    }
}
    

