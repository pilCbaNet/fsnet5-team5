using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            using (var db = new Pil2022Context())
            {
                return db.Usuarios.ToList();
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario? Get(int id)
        {
            using (var db = new Pil2022Context())
            {
                return db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            using (var db = new Pil2022Context())
            {
                var existeUsuario = db.Usuarios.FirstOrDefault(x => x.Dni == usuario.Dni);
                if(existeUsuario != null)
                {
                    return BadRequest("El usuario que quiere registrar, ya se encuentra registrado anteriormente.");
                }
                db.Add(usuario);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPost("baja/{id:int}")]
        public ActionResult PostEstado(int id)
        {
            using (var db = new Pil2022Context())
            {
                var existeUsuario = db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (existeUsuario == null)
                {
                    return NotFound();
                }
                existeUsuario.FehcaBaja = DateTime.Now;
                db.SaveChanges();
                return Ok();
            }
        }


        // PUT api/<UsuarioController>/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Usuario usuario)
        {
            using (var db = new Pil2022Context())
            {
                if(usuario.IdUsuario != id)
                {
                    return NotFound();
                }
                db.Update(usuario);
                db.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            using (var db = new Pil2022Context())
            {
                try
                {
                    var existeUsuario = db.Usuarios.Any(x => x.IdUsuario == id);
                    if (existeUsuario == null)
                    {
                        return NotFound();
                    }
                    db.Remove(new Usuario() { IdUsuario = id });
                    db.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }
    }
}
