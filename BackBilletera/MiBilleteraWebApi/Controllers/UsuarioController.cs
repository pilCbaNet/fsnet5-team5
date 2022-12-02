using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
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
                    return NotFound();
                }
                db.Add(usuario);
                db.SaveChanges();
                return Ok();
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Usuario usuario)
        {
            using (var db = new Pil2022Context())
            {
                var existeUsuario = db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
                if(existeUsuario!= null)
                {
                    db.Update(usuario);
                    db.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new Pil2022Context())
            {
                var existeUsuario = db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (existeUsuario == null)
                {
                    return NotFound();
                }
                db.Remove(new Usuario() { IdUsuario = id});
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
