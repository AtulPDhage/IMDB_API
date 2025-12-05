using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using DB_IMDB.Service.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DB_IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var actor =_actorService.GetAll();
            return Ok(actor);
           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var actor = _actorService.GetById(id);
            if (actor == null)
                return NotFound();

            return Ok(actor);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Model.Request.Actors request)
        {
            _actorService.Add(request);
            return CreatedAtAction(nameof(GetById),new {id=request.Id},request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Model.Request.Actors request)
        {
            var existing =_actorService.GetById(id);
            if (existing == null)
                return NotFound();

            _actorService.Update(id, request);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Model.Request.Actors request)
        {
            var existing = _actorService.GetById(id);
            if (existing == null)
                return NotFound();

            _actorService.PartialUpdate(id, request);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing =  _actorService.GetById(id);
            if (existing == null)
                return NotFound();

             _actorService.Delete(id);
            return NoContent();
        }
    }
}
