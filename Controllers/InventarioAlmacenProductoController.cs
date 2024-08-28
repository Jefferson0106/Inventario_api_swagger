
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;
namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioAlmacenProductoController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public InventarioAlmacenProductoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var InventarioAlmacenProducto = _dbcontext.InventarioAlmacenProductos.Select(r => new
                {
                    r.IdInventarioAlmacenProducto,
                    r.IdAlmacen,
                    r.IdProducto,
                    r.IdInventario,

                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición fue  realizada  ", response = InventarioAlmacenProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdInventarioAlmacenProducto:int}")]
        public IActionResult Obtener(int IdInventarioAlmacenProducto)
        {
            InventarioAlmacenProducto InventarioAlmacenProductos = _dbcontext.InventarioAlmacenProductos.Find(IdInventarioAlmacenProducto);

            if (InventarioAlmacenProductos == null)
            {
                return BadRequest(" no existe");

            }

            try
            {

                var InventarioAlmacenProducto = _dbcontext.InventarioAlmacenProductos.Select(r => new
                {
                    r.IdAlmacen,
                    r.IdProducto,
                    r.IdInventario,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = InventarioAlmacenProductos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] InventarioAlmacenProducto objeto)
        {
            try
            {
                var CreacionInventarioAlmacenProductos = new InventarioAlmacenProducto { IdAlmacen = objeto.IdAlmacen, IdProducto = objeto.IdProducto, IdInventario = objeto.IdInventario, };


                _dbcontext.InventarioAlmacenProductos.Add(CreacionInventarioAlmacenProductos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedcolores = CreacionInventarioAlmacenProductos, mensaje = "Su peticion se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] InventarioAlmacenProducto objeto)
        {
            InventarioAlmacenProducto InventarioAlmacenProductos = _dbcontext.InventarioAlmacenProductos.Find(objeto.IdInventarioAlmacenProducto);

            if (InventarioAlmacenProductos == null)
            {
                return BadRequest(" lo siento su peticion no ha sido encontrada ");
            }

            try
            {
                InventarioAlmacenProductos.IdAlmacen = objeto.IdAlmacen;
                InventarioAlmacenProductos.IdProducto = objeto.IdProducto;
                InventarioAlmacenProductos.IdInventario = objeto.IdInventario;

                _dbcontext.InventarioAlmacenProductos.Update(InventarioAlmacenProductos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su peticion Se ha Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdInventarioAlmacenProducto:int}")]
        public IActionResult Eliminar(int IdInventarioAlmacenProducto)
        {

            InventarioAlmacenProducto InventarioAlmacenProductos = _dbcontext.InventarioAlmacenProductos.Find(IdInventarioAlmacenProducto);

            if (InventarioAlmacenProductos == null)
            {
                return BadRequest(" no existe lo siento");

            }

            try
            {

                _dbcontext.InventarioAlmacenProductos.Remove(InventarioAlmacenProductos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " Se Elimino Exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}

