using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/monedas")]
    [ApiController]
    public class MonedasController : ControllerBase
    {

        private readonly Pil2022Context context;

        public MonedasController(Pil2022Context context)
        {
            this.context = context;
        }


        // GET: api/monedas
        [HttpGet]
        public List<Moneda> Get()
        {
            return context.Monedas.ToList();
        }

        // GET api/monedas/5
        [HttpGet("{id:int}")]
        public ActionResult<Moneda> Get(int id)
        {
            var existeMoneda = context.Monedas.FirstOrDefault(x => x.IdMoneda == id);
            if(existeMoneda == null)
            {
                return NotFound();
            }
            return Ok(existeMoneda);
        }

        // POST api/monedas
        [HttpPost]
        public ActionResult Post(Moneda moneda)
        {
            //esta validacion me parece que mejor seria hacerla por NOMBRE. CAMBIAR ESO EN BD!!
            var existeMoneda = context.Monedas.FirstOrDefault(x => x.IdMoneda == moneda.IdMoneda);
            if (existeMoneda != null)
            {
                return BadRequest("La moneda que quiere registrar, ya se encuentra registrada anteriormente.");
            }
            context.Add(moneda);
            context.SaveChanges();
            return Ok();
        }

        // PUT api/monedas/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Moneda moneda)
        {
            if (moneda.IdMoneda != id)
            {
                return NotFound();
            }
            context.Update(moneda);
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/monedas/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var existeMoneda = context.Monedas.FirstOrDefault(x => x.IdMoneda == id);
            if (existeMoneda == null)
            {
                return NotFound();
            }
            context.Remove(new Moneda() { IdMoneda = id });
            context.SaveChanges();
            return Ok();
        }
    }
}
