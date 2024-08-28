using Javier_Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaSubColorController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public BusquedaSubColorController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetUsuarios(int pagina, int cantidadPorPagina, string Nombre)
        {
            var SubColor = _dbcontext.Colores.AsQueryable();
            if (!string.IsNullOrEmpty(Nombre))
            {
                SubColor = SubColor.Where(u => u.Nombre == Nombre);
            }
            if (!string.IsNullOrEmpty(Nombre))
            {
                SubColor = SubColor.Where(u => u.Nombre == Nombre);
            }

            var totalPaginas = (int)Math.Ceiling(SubColor.Count() / (double)cantidadPorPagina);

            var SubColorEnPagina = SubColor
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToList();

            return Ok(new { Color = SubColorEnPagina, PaginaActual = pagina, TotalPaginas = totalPaginas });
        }
    }
}
    

