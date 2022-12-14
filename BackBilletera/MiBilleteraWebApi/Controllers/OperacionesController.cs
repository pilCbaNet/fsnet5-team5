using MiBilleteraWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiBilleteraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        private readonly Pil2022Context context;

        public OperacionesController(Pil2022Context context)
        {
            this.context = context;
        }

            [HttpGet("{id}")]
            public List<Operacion> Get(int id)
            {
                var lista = context.Operaciones.ToList().Where(x => x.IdUsuario == id).OrderByDescending(x => x.FechaOperacion);
                return lista.ToList();
            }



    }
}