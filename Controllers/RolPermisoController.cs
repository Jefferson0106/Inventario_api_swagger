
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;
using System.Drawing;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolPermisoController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public RolPermisoController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var RolPermiso = _dbcontext.RolPermisos.Select(r => new
                {
                    r.IdRolPermiso,
                    r.IdRol,
                    r.IdPermiso,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = RolPermiso });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdRolPermiso:int}")]
        public IActionResult Obtener(int IdRolPermiso)
        {
            RolPermiso RolPermisos = _dbcontext.RolPermisos.Find(IdRolPermiso);

            if (RolPermisos == null)
            {
                return BadRequest(" lo siento El Rol no existe");

            }

            try
            {

                var RolPermiso = _dbcontext.RolPermisos.Select(r => new
                {
                    r.IdRol,
                    r.IdPermiso
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = RolPermisos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] RolPermiso objeto)
        {
            try
            {
                var creacionRolPermiso = new RolPermiso { IdRol = objeto.IdPermiso };


                _dbcontext.RolPermisos.Add(creacionRolPermiso);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedcolores = creacionRolPermiso, mensaje = "Su peticion se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] RolPermiso objeto)
        {
            RolPermiso RolPermisos = _dbcontext.RolPermisos.Find(objeto.IdRolPermiso);

            if (RolPermisos == null)
            {
                return BadRequest(" lo siento su peticion no ha sido encontrada ");
            }

            try
            {
                RolPermisos.IdRol = objeto.IdRol;
                RolPermisos.IdPermiso = objeto.IdPermiso;



                _dbcontext.RolPermisos.Update(RolPermisos);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su peticion Se ha Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdRolPermiso:int}")]
        public IActionResult Eliminar(int IdRolPermiso)
        {

            RolPermiso RolPermisos = _dbcontext.RolPermisos.Find(IdRolPermiso);

            if (RolPermisos == null)
            {
                return BadRequest(" no existe lo siento");

            }

            try
            {

                _dbcontext.RolPermisos.Remove(RolPermisos);
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

