using ExcursionesPescaEntities;
using ExcursionesPescaService;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionesPescaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExcursionesLagoController : ControllerBase
    {
        private ExcursionesLagoService excursionesLagoService;

        public ExcursionesLagoController()
        {
            excursionesLagoService = new ExcursionesLagoService();
        }

        [HttpGet()]
        public IEnumerable<ExcursionLago> Get()
        {
            return excursionesLagoService.ObtenerExcursiones();
        }

        [HttpGet("{id}")]
        public IEnumerable<ExcursionLago> Get(int id)
        {
            return excursionesLagoService.ObtenerExcursionesPorId(id);
        }

        [HttpPost()]
        public bool Post([FromBody] ExcursionLago excursionLago)
        {
            return excursionesLagoService.AgregarExcursion(excursionLago);
        }

        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] ExcursionLago excursionLago)
        {
            return excursionesLagoService.EditarExcursion(id, excursionLago);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return excursionesLagoService.EliminarExcursion(id);
        }
    }
}
