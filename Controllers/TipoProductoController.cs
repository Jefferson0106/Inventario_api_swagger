using Javier_Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public TipoProductoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var TipoProducto = _dbcontext.TipoProductos.Select(r => new

                {
                    r.IdTipoProducto,
                    r.Nombre,
                    r.Descripcion,
                    r.IdColor,
                    r.IdSubColor,
                    r.FechaCreacion,

                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = TipoProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdTipoProducto:int}")]
        public IActionResult Obtener(int IdTipoProducto)
        {
            TipoProducto TipoProductos = _dbcontext.TipoProductos.Find(IdTipoProducto);

            if (TipoProductos == null)
            {
                return BadRequest(" este tipo de producto no existe ");

            }

            try
            {

                var TipoPruducto = _dbcontext.TipoProductos.Select(r => new
                {

                    r.IdTipoProducto,
                    r.Nombre,
                    r.Descripcion,
                    r.IdColor,
                    r.IdSubColor,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = TipoProductos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] TipoProducto objeto)
        {
            try
            {
                var TipoPruducto = new TipoProducto { Nombre = objeto.Nombre, Descripcion = objeto.Descripcion, IdColor = objeto.IdColor, IdSubColor = objeto.IdSubColor, FechaCreacion = objeto.FechaCreacion, };


                _dbcontext.TipoProductos.Add(TipoPruducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedTipoProducto = TipoPruducto, mensaje = "Su peticion ha sido aceptada" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] TipoProducto objeto)
        {
            TipoProducto tipoProductos = _dbcontext.TipoProductos.Find(objeto.IdTipoProducto);

            if (tipoProductos == null)
            {
                return BadRequest(" lo siento su usuario no ha sido encontrado ");
            }

            try
            {
                tipoProductos.Nombre = objeto.Nombre;
                tipoProductos.Descripcion = objeto.Descripcion;
                tipoProductos.IdColor = objeto.IdColor;
                tipoProductos.IdSubColor = objeto.IdSubColor;
                tipoProductos.FechaCreacion = objeto.FechaCreacion;



                _dbcontext.TipoProductos.Update(tipoProductos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "se ha actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdTipoProducto:int}")]
        public IActionResult Eliminar(int IdTipoProducto)
        {

            TipoProducto tipoProductos = _dbcontext.TipoProductos.Find(IdTipoProducto);

            if (tipoProductos == null)
            {
                return BadRequest("usuario no encontrado");

            }

            try
            {

                _dbcontext.TipoProductos.Remove(tipoProductos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}