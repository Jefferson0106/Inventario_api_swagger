using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Javier_Inventario.Models;

namespace Javier_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly dbProyecto_InventarioContext _dbcontext;

        public UsuarioController(dbProyecto_InventarioContext _context)
        {
            _dbcontext = _context;

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var Usuarios = _dbcontext.Usuarios.Select(r => new

                {
                    r.IdUsuario,
                    r.NombreCompleto,
                    r.ApellidoCompleto,
                    r.Correo,
                    r.Contrasena,
                    r.Cedula,
                    r.Telefono,
                    r.IdRol,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = Usuarios });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdUsuario:int}")]
        public IActionResult Obtener(int IdUsuario)
        {
            Usuario usuarios = _dbcontext.Usuarios.Find(IdUsuario);

            if (usuarios == null)
            {
                return BadRequest(" lo siento El usuario  no existe");

            }

            try
            {

                var usuariosCreacion = _dbcontext.Usuarios.Select(r => new
                {
                    r.IdUsuario,
                    r.NombreCompleto,
                    r.ApellidoCompleto,
                    r.Correo,
                    r.Contrasena,
                    r.Cedula,
                    r.Telefono,
                    r.IdRol,
                    r.FechaCreacion,
                }).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Petición realizada exitosamente", response = usuarios });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });


            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Usuario objeto)
        {
            try
            {
                var creacionUsuario = new Usuario { NombreCompleto = objeto.NombreCompleto, ApellidoCompleto = objeto.ApellidoCompleto, Correo = objeto.Correo, Contrasena = objeto.Contrasena, Cedula = objeto.Cedula, Telefono = objeto.Telefono, IdRol = objeto.IdRol };


                _dbcontext.Usuarios.Add(creacionUsuario);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { savedRole = creacionUsuario, mensaje = "Su usuario  se ha creado y Guardado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Usuario objeto)
        {
            Usuario usuarios = _dbcontext.Usuarios.Find(objeto.IdUsuario);

            if (usuarios == null)
            {
                return BadRequest(" lo siento su usuario no ha sido encontrado ");
            }

            try
            {
                usuarios.NombreCompleto = objeto.NombreCompleto;
                usuarios.ApellidoCompleto = objeto.ApellidoCompleto;
                usuarios.Correo = objeto.Correo;
                usuarios.Contrasena = objeto.Contrasena;
                usuarios.Cedula = objeto.Cedula;
                usuarios.Telefono = objeto.Telefono;
                usuarios.IdRol = objeto.IdRol;
                usuarios.FechaCreacion = objeto.FechaCreacion;


                _dbcontext.Usuarios.Update(usuarios);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su usuario Se Actualizo Correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idUsuario:int}")]
        public IActionResult Eliminar(int idUsuario)
        {

            Usuario usuarios = _dbcontext.Usuarios.Find(idUsuario);

            if (usuarios == null)
            {
                return BadRequest("usuario no encontrado");

            }

            try
            {

                _dbcontext.Usuarios.Remove(usuarios);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su usuario Se Elimino Exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

    }
}

