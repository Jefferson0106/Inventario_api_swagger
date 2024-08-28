using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public CategoriaController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var Categoria = _dbcontext.Categoria.Select(r => new
                {
                    r.IdCategoria,
                    r.Nombre,
                    r.Descripcion,
                    r.Marca,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = Categoria });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdCategoria:int}")]
        public IActionResult Obtener(int IdCategoria)
        {
            Categoria Categorias = _dbcontext.Categoria.Find(IdCategoria);

            if (Categorias == null)
            {
                return BadRequest(" lo siento El Categoria no existe");

            }

            try
            {

                var Categoria = _dbcontext.Categoria.Select(r => new
                {
                    r.IdCategoria,
                    r.Nombre,
                    r.Descripcion,
                    r.Marca,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = Categorias });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Categoria objeto)
        {
            try
            {
                var CreacionCategoria = new Categoria { Nombre = objeto.Nombre, Descripcion = objeto.Descripcion, Marca = objeto.Marca };


                _dbcontext.Categoria.Add(CreacionCategoria);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedRole = CreacionCategoria, mensaje = "Su Categoria  se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Categoria objeto)
        {
            Categoria Categoriasl = _dbcontext.Categoria.Find(objeto.IdCategoria);

            if (Categoriasl == null)
            {
                return BadRequest(" lo siento su Categoria no ha sido encomtrado ");
            }

            try
            {
                Categoriasl.Nombre = objeto.Nombre;
                Categoriasl.Descripcion = objeto.Descripcion;
                Categoriasl.Marca = objeto.Marca;




                _dbcontext.Categoria.Update(Categoriasl);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Categoria Se Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdCategoria:int}")]
        public IActionResult Eliminar(int IdCategoria)
        {

            Categoria Categoriasl = _dbcontext.Categoria.Find(IdCategoria);

            if (Categoriasl == null)
            {
                return BadRequest("Categoria no encontrado");

            }

            try
            {

                _dbcontext.Categoria.Remove(Categoriasl);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Categoria Se Elimino Exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
