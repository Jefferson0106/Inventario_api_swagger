
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Javier_Inventario.Models;
using System.Drawing;
namespace Javier_Inventario.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColoreController : ControllerBase
{

    public readonly dbProyecto_InventarioContext _dbcontext;

    public ColoreController(dbProyecto_InventarioContext _context)
    {
        _dbcontext = _context;

    }

    [HttpGet]
    [Route("Lista")]
    public IActionResult Lista()
    {
        try
        {
            var color = _dbcontext.Colores.Select(r => new
            {
                r.IdColor,
                r.Nombre,

            }).ToList();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = " La Petición realizada  fue exitosamente", response = color });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
        }
    }

    [HttpGet]
    [Route("Obtener/{IdColor:int}")]
    public IActionResult Obtener(int IdColor)
    {
        Colore Rols = _dbcontext.Colores.Find(IdColor);

        if (Rols == null)
        {
            return BadRequest(" lo siento El Rol no existe");

        }

        try
        {

            var Rol = _dbcontext.Colores.Select(r => new
            {
                r.IdColor,
                r.Nombre
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
    public IActionResult Guardar([FromBody] Colore objeto)
    {
        try
        {
            var creacioncolores = new Colore { Nombre = objeto.Nombre };


            _dbcontext.Colores.Add(creacioncolores);
            _dbcontext.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, new { savedcolores = creacioncolores, mensaje = "Su peticion se ha creado y Guardado" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
        }
    }

    [HttpPut]
    [Route("Editar")]
    public IActionResult Editar([FromBody] Colore objeto)
    {
        Colore colores = _dbcontext.Colores.Find(objeto.IdColor);

        if (colores == null)
        {
            return BadRequest(" lo siento su peticion no ha sido encontrada ");
        }

        try
        {
            colores.Nombre = objeto.Nombre;



            _dbcontext.Colores.Update(colores);
            _dbcontext.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Su peticion Se ha Actualizo Correctamente" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
        }
    }

    [HttpDelete]
    [Route("Eliminar/{IdColor:int}")]
    public IActionResult Eliminar(int IdColor)
    {

        Colore colores = _dbcontext.Colores.Find(IdColor);

        if (colores == null)
        {
            return BadRequest(" no existe lo siento");

        }

        try
        {

            _dbcontext.Colores.Remove(colores);
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

