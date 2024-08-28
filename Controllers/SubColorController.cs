using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubColorController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public SubColorController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var SubColores = _dbcontext.SubColors.Select(r => new
                {
                    r.IdSubColor,
                    r.Nombre,

                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = SubColores });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdSubColor:int}")]
        public IActionResult Obtener(int IdSubColor)
        {
            SubColor SubColores = _dbcontext.SubColors.Find(IdSubColor);

            if (SubColores == null)
            {
                return BadRequest(" lo siento El Rol no existe");

            }

            try
            {

                var SubColor = _dbcontext.SubColors.Select(r => new
                {
                    r.IdSubColor,
                    r.Nombre
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = SubColores });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SubColor objeto)
        {
            try
            {
                var CreacionSubColor = new SubColor { Nombre = objeto.Nombre };


                _dbcontext.SubColors.Add(CreacionSubColor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedcolores = CreacionSubColor, mensaje = "Su peticion se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] SubColor objeto)
        {
            SubColor SubColor = _dbcontext.SubColors.Find(objeto.IdSubColor);

            if (SubColor == null)
            {
                return BadRequest(" lo siento su peticion no ha sido encontrada ");
            }

            try
            {
                SubColor.Nombre = objeto.Nombre;



                _dbcontext.SubColors.Update(SubColor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su peticion Se ha Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdSubColor:int}")]
        public IActionResult Eliminar(int IdSubColor)
        {

            SubColor SubColores = _dbcontext.SubColors.Find(IdSubColor);

            if (SubColores == null)
            {
                return BadRequest(" no existe lo siento");

            }

            try
            {

                _dbcontext.SubColors.Remove(SubColores);
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
