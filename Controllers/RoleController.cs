using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;
namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public RoleController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var Rol = _dbcontext.Roles.Select(r => new
                {
                    r.IdRol,
                    r.NombreRol,
                    r.Descripcion,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = Rol });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdRol:int}")]
        public IActionResult Obtener(int IdRol)
        {
            Role Rols = _dbcontext.Roles.Find(IdRol);

            if (Rols == null)
            {
                return BadRequest(" lo siento El Rol no existe");

            }

            try
            {

                var Rol = _dbcontext.Roles.Select(r => new
                {
                    r.IdRol,
                    r.NombreRol,
                    r.Descripcion,
                    r.FechaCreacion,
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
        public IActionResult Guardar([FromBody] Role objeto)
        {
            try
            {
                var creacionrol = new Role { NombreRol = objeto.NombreRol, Descripcion = objeto.Descripcion };


                _dbcontext.Roles.Add(creacionrol);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedRole = creacionrol, mensaje = "Su Rol  se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Role objeto)
        {
            Role Rols = _dbcontext.Roles.Find(objeto.IdRol);

            if (Rols == null)
            {
                return BadRequest(" lo siento su Rol no ha sido encomtrado ");
            }

            try
            {
                Rols.NombreRol = objeto.NombreRol;
                Rols.Descripcion = objeto.Descripcion;


                _dbcontext.Roles.Update(Rols);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Rol Se Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{IdRol:int}")]
        public IActionResult Eliminar(int IdRol)
        {

            Role Rols = _dbcontext.Roles.Find(IdRol);

            if (Rols == null)
            {
                return BadRequest("Rol no encontrado");

            }

            try
            {

                _dbcontext.Roles.Remove(Rols);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su Rol Se Elimino Exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

    }
}
