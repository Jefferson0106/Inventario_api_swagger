
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;
namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {

        public readonly dbProyecto_InventarioContext _dbcontext;

        public PermisoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var permiso = _dbcontext.Permisos.Select(r => new
                {
                    r.IdPermiso,
                    r.Nombre,
                    r.Descripcion,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = permiso });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdPermiso:int}")]
        public IActionResult Obtener(int IdPermiso)
        {
            Permiso Rols = _dbcontext.Permisos.Find(IdPermiso);

            if (Rols == null)
            {
                return BadRequest(" lo siento El Rol no existe");

            }

            try
            {

                var Rol = _dbcontext.Permisos.Select(r => new
                {
                    r.IdPermiso,
                    r.Nombre,
                    r.Descripcion,
                    r.FechaCreacion
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = Rols });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Permiso objeto)
        {
            try
            {
                var permiso = new Permiso { Nombre = objeto.Nombre, Descripcion = objeto.Descripcion };


                _dbcontext.Permisos.Add(permiso);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedRole = permiso, mensaje = "Su solicitud ha sido creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Permiso objeto)
        {
            Permiso permisos = _dbcontext.Permisos.Find(objeto.IdPermiso);

            if (permisos == null)
            {
                return BadRequest(" lo lamento su solicitud no existe ");
            }

            try
            {
                permisos.Nombre = objeto.Nombre;
                permisos.Descripcion = objeto.Descripcion;


                _dbcontext.Permisos.Update(permisos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " Se Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idPermiso:int}")]
        public IActionResult Eliminar(int idPermiso)
        {

            Permiso permisos = _dbcontext.Permisos.Find(idPermiso);

            if (permisos == null)
            {
                return BadRequest(" su solicitud  no fue  encontrada");

            }

            try
            {

                _dbcontext.Permisos.Remove(permisos);
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