using Javier_Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaUsuarioController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public BusquedaUsuarioController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        public IActionResult GetUsuarios(int pagina, int cantidadPorPagina, string NombreCompleto)
        {
            var Usuario = _dbcontext.Usuarios.AsQueryable();
            if (!string.IsNullOrEmpty(NombreCompleto))
            {
                Usuario = Usuario.Where(u => u.NombreCompleto == NombreCompleto);
            }
            if (!string.IsNullOrEmpty(NombreCompleto))
            {
                Usuario = Usuario.Where(u => u.NombreCompleto == NombreCompleto);
            }

            var totalPaginas = (int)Math.Ceiling(Usuario.Count() / (double)cantidadPorPagina);

            var usuariosEnPagina = Usuario
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina)
                .ToList();

            return Ok(new { Usuarios = usuariosEnPagina, PaginaActual = pagina, TotalPaginas = totalPaginas });
        }
    }
}
    

