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
        private readonly Pil2022Context context;

        public UsuariosController(Pil2022Context context)
        {
            this.context = context;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            return context.Usuarios.ToList();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario? Get(int id)
        {
            return context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            var existeUsuario = context.Usuarios.FirstOrDefault(x => x.Dni == usuario.Dni);
            if(existeUsuario != null)
            {
                return BadRequest("El usuario que quiere registrar, ya se encuentra registrado anteriormente.");
            }
            context.Add(usuario);
            context.SaveChanges();
            return Ok();
        }

        [HttpPost("baja/{id:int}")]
        public ActionResult PostEstado(int id)
        {
            var existeUsuario = context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (existeUsuario == null)
            {
                return NotFound();
            }
            existeUsuario.FehcaBaja = DateTime.Now;
            context.SaveChanges();
            return Ok();
        }


        // PUT api/<UsuarioController>/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Usuario usuario)
        {
            if(usuario.IdUsuario != id)
            {
                return NotFound();
            }
            context.Update(usuario);
            context.SaveChanges();
            return Ok();
            
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existeUsuario = context.Usuarios.Any(x => x.IdUsuario == id);
            if (existeUsuario == null)
            {
                return NotFound();
            }
             context.Remove(new Usuario() { IdUsuario = id });
             context.SaveChangesAsync();
            return Ok();
        }
    }
}
