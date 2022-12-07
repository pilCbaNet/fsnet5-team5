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

        [HttpPost]
        public ActionResult PostRetiro(RetiroBillertera retiroBillertera)
        {
            
                var retiro = context.Billeteras.FirstOrDefault(x => x.IdBilletera == retiroBillertera.IdBilletera);
                if (retiroBillertera.Saldo == 0)
                {
                    return BadRequest("La billetera NO tiene saldo.");
                }
                else
                {
                    var montoRetirado = retiro.Saldo - retiroBillertera.Saldo;

                    retiro.Saldo = montoRetirado;
                    retiro.IdUsuario = retiroBillertera.IdUsuario;
                    retiro.IdMoneda = 1;

                    context.SaveChanges();
                    return Ok(retiro);
                }


            
        }


        [HttpPost]
        [Route("Sumar")]
        public ActionResult PostIngresar(RetiroBillertera retiroBillertera)
        {
            
            
                var retiro = context.Billeteras.FirstOrDefault(x => x.IdBilletera == retiroBillertera.IdBilletera);
                if (retiroBillertera.Saldo == 0)
                {
                    return BadRequest("La billetera NO tiene saldo.");
                }
                else
                {
                    var montoRetirado = retiro.Saldo + retiroBillertera.Saldo;

                    retiro.Saldo = montoRetirado;
                    retiro.IdUsuario = retiroBillertera.IdUsuario;
                    retiro.IdMoneda = 1;

                context.SaveChanges();
                    return Ok(retiro);
                }


            
        }

    }

}
