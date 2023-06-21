using APIMongoDBC_.Models;
using APIMongoDBC_.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMongoDBC_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }


        // GET: api/<VehiclesController>
        [HttpGet]
        public ActionResult<List<Automovil>> Get()
        {
            return vehicleService.Get();
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public ActionResult<Automovil> Get(string id)
        {
            var vehicle = vehicleService.Get(id);
            if(vehicle == null)
            {
                return NotFound($"Vehicle with Id= {id} not found");
            }
            return vehicle;
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public ActionResult<Automovil> Post(Automovil automovil)
        {
            vehicleService.Create(automovil);
            return CreatedAtAction(nameof(Get), new { id = automovil.Id }, automovil);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut]
        public ActionResult Put(Automovil automovil)
        {
            /* var existingAutomovil = vehicleService.Get(id);
            if(existingAutomovil == null)
            {
                return NotFound("Not exist that automovil");
            }*/
            vehicleService.Update(automovil.Id, automovil);
            return Ok();
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var automovil = vehicleService.Get(id);
            if (automovil == null)
            {
                return NotFound("Not exist that automovil");
            }
            vehicleService.Remove(automovil.Id);
            return Ok("Vehicle Deleted");
        } 
    }
}
