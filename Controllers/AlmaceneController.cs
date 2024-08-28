using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmaceneController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public AlmaceneController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var Almacene = _dbcontext.Almacenes.Select(r => new
                {
                    r.IdAlmacen,
                    r.NombreAlmacen,
                    r.Ubicacion,
                    r.Descripcion,
                    r.IdUsuario,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = Almacene });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdAlmacen:int}")]
        public IActionResult Obtener(int IdAlmacen)
        {
            Almacene Almacenes = _dbcontext.Almacenes.Find(IdAlmacen);

            if (Almacenes == null)
            {
                return BadRequest(" lo siento El Almacen no existe");

            }

            try
            {

                var Almacene = _dbcontext.Almacenes.Select(r => new
                {
                    r.IdAlmacen,
                    r.NombreAlmacen,
                    r.Ubicacion,
                    r.Descripcion,
                    r.IdUsuario,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = Almacenes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Almacene objeto)
        {
            try
            {
                var CreacionAlmacen = new Almacene { NombreAlmacen = objeto.NombreAlmacen, Ubicacion = objeto.Ubicacion, Descripcion = objeto.Descripcion, IdUsuario = objeto.IdUsuario };


                _dbcontext.Almacenes.Add(CreacionAlmacen);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedRole = CreacionAlmacen, mensaje = "Su Almacen  se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Almacene objeto)
        {
            Almacene Almacens = _dbcontext.Almacenes.Find(objeto.IdAlmacen);

            if (Almacens == null)
            {
                return BadRequest(" lo siento su Almacen no ha sido encomtrado ");
            }

            try
            {
                Almacens.NombreAlmacen = objeto.NombreAlmacen;
                Almacens.Ubicacion = objeto.Ubicacion;
                Almacens.Descripcion = objeto.Descripcion;
                Almacens.IdUsuario = objeto.IdUsuario;





                _dbcontext.Almacenes.Update(Almacens);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Almacen Se Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdAlmacen:int}")]
        public IActionResult Eliminar(int IdAlmacen)
        {

            Almacene Almacens = _dbcontext.Almacenes.Find(IdAlmacen);

            if (Almacens == null)
            {
                return BadRequest("Almacen no encontrado");

            }

            try
            {

                _dbcontext.Almacenes.Remove(Almacens);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Almacen Se Elimino Exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
