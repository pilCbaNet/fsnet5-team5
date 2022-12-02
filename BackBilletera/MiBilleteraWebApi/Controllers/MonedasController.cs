using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/monedas")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        // GET: api/monedas
        [HttpGet]
        public List<Moneda> Get()
        {
            using (var db = new Pil2022Context()) 
            { 
                return db.Monedas.ToList();
            }
        }

        // GET api/monedas/5
        [HttpGet("{id:int}")]
        public ActionResult<Moneda> Get(int id)
        {
            using (var db = new Pil2022Context())
            {
                var existeMoneda = db.Monedas.FirstOrDefault(x => x.IdMoneda == id);
                if(existeMoneda == null)
                {
                    return NotFound();
                }
                return Ok(existeMoneda);
            }
        }

        // POST api/monedas
        [HttpPost]
        public ActionResult Post(Moneda moneda)
        {
            using (var db = new Pil2022Context())
            {
                //esta validacion me parece que mejor seria hacerla por NOMBRE. CAMBIAR ESO EN BD!!
                var existeMoneda = db.Monedas.FirstOrDefault(x => x.IdMoneda == moneda.IdMoneda);
                if (existeMoneda != null)
                {
                    return BadRequest("La moneda que quiere registrar, ya se encuentra registrada anteriormente.");
                }
                db.Add(moneda);
                db.SaveChanges();
                return Ok();
            }
        }

        // PUT api/monedas/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Moneda moneda)
        {
            using (var db = new Pil2022Context())
            {
                if (moneda.IdMoneda != id)
                {
                    return NotFound();
                }
                db.Update(moneda);
                db.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/monedas/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            using (var db = new Pil2022Context())
            {
                var existeMoneda = db.Monedas.FirstOrDefault(x => x.IdMoneda == id);
                if (existeMoneda == null)
                {
                    return NotFound();
                }
                db.Remove(new Moneda() { IdMoneda = id });
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
