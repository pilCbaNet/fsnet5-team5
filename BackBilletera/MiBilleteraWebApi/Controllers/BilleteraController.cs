using Entities.Models;
using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/billetera")]
    [ApiController]
    public class BilleteraController : ControllerBase
    {

        private readonly Pil2022Context context;

        public BilleteraController(Pil2022Context context)
        {
            this.context = context;
        }

        [HttpPost("Retiro")]
        public ActionResult PostRetiro(RetiroBillertera retiroBillertera)
        {

            var retiro = context.Billeteras.FirstOrDefault(x => x.IdUsuario == retiroBillertera.IdUsuario);
            if (retiroBillertera.Saldo == 0)
            {
                return BadRequest("La billetera NO tiene saldo.");
            }
            else
            {
                var montoRetirado = retiro.Saldo - retiroBillertera.Saldo;

                retiro.Saldo = montoRetirado;
                retiro.IdMoneda = 1;
                    


                var operaciones = new Operacion()
                {

                    Monto = retiroBillertera.Saldo,
                    FechaOperacion = DateTime.Now,
                    IdUsuario = retiro.IdUsuario,
                    IdBilletera = retiro.IdBilletera,
                    IdMoneda = 1,
                    IdTipoOperacion = 3,


                };

                context.Add(operaciones);
                context.SaveChanges();
                return Ok(retiro);



            }



        }


        [HttpPost("Deposito")]
        
        public ActionResult PostIngresar(RetiroBillertera retiroBillertera)
        {


            var retiro = context.Billeteras.FirstOrDefault(x => x.IdUsuario == retiroBillertera.IdUsuario);
            if (retiroBillertera.Saldo == 0)
            {
                return BadRequest("La billetera NO tiene saldo.");
            }
            else
            {
                var montoRetirado = retiro.Saldo + retiroBillertera.Saldo;

                retiro.Saldo = montoRetirado;
                retiro.IdMoneda = 1;

                var operaciones = new Operacion()
                {

                    Monto = retiroBillertera.Saldo,
                    FechaOperacion = DateTime.Today,
                    IdUsuario = retiro.IdUsuario,
                    IdBilletera = retiro.IdBilletera,
                    IdMoneda = 1,
                    IdTipoOperacion = 5,

                };

                context.Add(operaciones);
                context.SaveChanges();
                return Ok(retiro);
            }



        }
        [HttpGet("{id:int}")]
        public ActionResult<Billetera> GetSaldo(int id)
        {


            var billetera = context.Billeteras.FirstOrDefault(x => x.IdUsuario == id);

            if (billetera == null)
            {
                return NotFound();
            }
            return Ok(billetera.Saldo);

        }



    }

}
