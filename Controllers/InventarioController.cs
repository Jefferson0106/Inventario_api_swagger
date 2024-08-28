using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public InventarioController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var Inventario = _dbcontext.Inventarios.Select(r => new
                {
                    r.IdInventario,
                    r.FechaPrestamo,
                    r.FechaEntrega,
                    r.Estado,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = Inventario });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdInventario:int}")]
        public IActionResult Obtener(int IdInventario)
        {
            Inventario Inventarios = _dbcontext.Inventarios.Find(IdInventario);

            if (Inventarios == null)
            {
                return BadRequest(" lo siento El Inventario no existe");

            }

            try
            {

                var Inventario = _dbcontext.Inventarios.Select(r => new
                {
                    r.IdInventario,
                    r.FechaPrestamo,
                    r.FechaEntrega,
                    r.Estado,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = Inventarios });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Inventario objeto)
        {
            try
            {
                var CreacionInventario = new Inventario { FechaPrestamo = objeto.FechaPrestamo, FechaEntrega = objeto.FechaEntrega, Estado = objeto.Estado };


                _dbcontext.Inventarios.Add(CreacionInventario);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedRole = CreacionInventario, mensaje = "Su Inventario  se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Inventario objeto)
        {
            Inventario Inventaris = _dbcontext.Inventarios.Find(objeto.IdInventario);

            if (Inventaris == null)
            {
                return BadRequest(" lo siento su Inventario no ha sido encomtrado ");
            }

            try
            {
                Inventaris.FechaPrestamo = objeto.FechaPrestamo;
                Inventaris.FechaEntrega = objeto.FechaEntrega;
                Inventaris.Estado = objeto.Estado;





                _dbcontext.Inventarios.Update(Inventaris);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Inventario Se Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdInventario:int}")]
        public IActionResult Eliminar(int IdInventario)
        {

            Inventario Inventaris = _dbcontext.Inventarios.Find(IdInventario);

            if (Inventaris == null)
            {
                return BadRequest("Inventario no encontrado");

            }

            try
            {

                _dbcontext.Inventarios.Remove(Inventaris);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Inventario Se Elimino Exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}

