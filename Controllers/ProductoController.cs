using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Javier_Inventario.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public ProductoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var Productos = _dbcontext.Productos.Select(r => new

                {
                    r.IdProducto,
                    r.NombreProducto,
                    r.CodigoProducto,
                    r.Stoks,
                    r.Descripcion,
                    r.UbicacionProducto,
                    r.Estatus,
                    r.IdCategoria,
                    r.IdTipoProducto,
                    r.IdColor,
                    r.IdSubColor,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " se ejecuto correctamente", response = Productos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdProducto:int}")]
        public IActionResult Obtener(int IdProducto)
        {
            Producto Productos = _dbcontext.Productos.Find(IdProducto);

            if (Productos == null)
            {
                return BadRequest(" lo siento El producto no existe");

            }

            try
            {

                var ProductoCreacion = _dbcontext.Productos.Select(r => new
                {
                    r.IdProducto,
                    r.NombreProducto,
                    r.CodigoProducto,
                    r.Stoks,
                    r.Descripcion,
                    r.UbicacionProducto,
                    r.Estatus,
                    r.IdCategoria,
                    r.IdTipoProducto,
                    r.IdColor,
                    r.IdSubColor,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "se ejecuto correctamente ", response = Productos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Producto objeto)
        {
            try
            {
                var ProductoCreacion = new Producto { NombreProducto = objeto.NombreProducto, CodigoProducto = objeto.CodigoProducto, Stoks = objeto.Stoks, Descripcion = objeto.Descripcion, UbicacionProducto = objeto.UbicacionProducto, Estatus = objeto.Estatus, IdCategoria = objeto.IdCategoria, IdTipoProducto = objeto.IdTipoProducto, IdColor = objeto.IdColor, IdSubColor = objeto.IdSubColor, FechaCreacion = objeto.FechaCreacion, };


                _dbcontext.Productos.Add(ProductoCreacion);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedProducto = ProductoCreacion, mensaje = "se guardo y creo su producto" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Producto objeto)
        {
            Producto Productos = _dbcontext.Productos.Find(objeto.IdProducto);

            if (Productos == null)
            {
                return BadRequest(" el producto no existe ");
            }

            try
            {
                Productos.NombreProducto = objeto.NombreProducto;
                Productos.CodigoProducto = objeto.CodigoProducto;
                Productos.Stoks = objeto.Stoks;
                Productos.Descripcion = objeto.Descripcion;
                Productos.UbicacionProducto = objeto.UbicacionProducto;
                Productos.Estatus = objeto.Estatus;
                Productos.IdCategoria = objeto.IdCategoria;
                Productos.IdTipoProducto = objeto.IdTipoProducto;
                Productos.IdColor = objeto.IdColor;
                Productos.IdSubColor = objeto.IdSubColor;
                Productos.FechaCreacion = objeto.FechaCreacion;

                _dbcontext.Productos.Update(Productos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "se actulizo correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdProducto:int}")]
        public IActionResult Eliminar(int IdProducto)
        {

            Producto Productos = _dbcontext.Productos.Find(IdProducto);

            if (Productos == null)
            {
                return BadRequest("usuario no encontrado");

            }

            try
            {

                _dbcontext.Productos.Remove(Productos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
