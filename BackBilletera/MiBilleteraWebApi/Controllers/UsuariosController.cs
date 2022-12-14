using Entities.Models;
using Jose;
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
        [HttpGet("{token}")]
        public Usuario? Get(string token)
        {

            var secretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };
            string email = DesEncriptado(token, secretKey);

            return context.Usuarios.FirstOrDefault(x => x.Email == email);
        }

        [HttpPost]
        [Route("Inicio")]

        public ActionResult PostIniciar(Logeo usuario)
        {
            var existeUsuario = context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);
            if (existeUsuario == null)
            {
                return BadRequest("El usuario que quiere Ingresar, no esta registrado.");
            }
            if (existeUsuario.FechaBaja != null)
            {
                return BadRequest("El usuario esta dado de baja");
            }
            context.SaveChanges();
            var secretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };

            var encripto = Encriptado(usuario.Email, secretKey);

            TokenJson tok = new TokenJson();

            tok.token = encripto;

            return Ok(tok);
        }
        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            var existeUsuario = context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);
            if(existeUsuario != null)
            {
                return BadRequest("El usuario que quiere registrar, ya se encuentra registrado anteriormente.");
            }
            
            context.Add(usuario);
            context.SaveChanges();
            var usuarioCreado = context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);
            var billetera = new Billetera
            {
                Saldo = 0,
                IdMoneda = 1,
                IdUsuario = usuarioCreado.IdUsuario,
            };
            context.Add(billetera);
            context.SaveChanges();
            var secretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };

            var encripto = Encriptado(usuario.Email, secretKey);

            TokenJson tok = new TokenJson();

            tok.token = encripto;

            return Ok(tok);

        }

        [HttpPost("baja/{id:int}")]
        public ActionResult PostEstado(int id)
        {
            var existeUsuario = context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (existeUsuario == null)
            {
                return NotFound();
            }
            if(existeUsuario.FechaBaja != null)
            {
                existeUsuario.FechaBaja = null;
            }
            else
            {
                existeUsuario.FechaBaja = DateTime.Now;
            }
            context.Update(existeUsuario);
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
            usuario.FechaBaja = null;
            context.Update(usuario);
            context.SaveChanges();
            return Ok();
        }




        static public string Encriptado(string payload, byte[] secretKey)
        {
            return Jose.JWT.Encode(payload, secretKey, JweAlgorithm.DIR, JweEncryption.A128CBC_HS256);
        }

        static public string DesEncriptado(string encriptar, byte[] secretKey)
        {
            return Jose.JWT.Decode(encriptar, secretKey, JweAlgorithm.DIR, JweEncryption.A128CBC_HS256);
        }

        public class TokenJson
        {
            public string token { get; set; }
        }

    }
}
