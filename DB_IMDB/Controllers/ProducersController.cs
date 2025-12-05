using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using DB_IMDB.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB_IMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var producer = _producerService.GetAll();
            return Ok(producer);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var producer =  _producerService.GetById(id);
            if (producer == null)
                return NotFound();

            return Ok(producer);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Model.Request.Producers request)
        {
            _producerService.Add(request);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Model.Request.Producers request)
        {
            var existing =  _producerService.GetById(id);
            if (existing == null)
                return NotFound();

             _producerService.Update(id, request);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Model.Request.Producers request)
        {
            var existing = _producerService.GetById(id);
            if (existing == null)
                return NotFound();

            _producerService.PartialUpdate(id, request);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _producerService.GetById(id);
            if (existing == null)
                return NotFound();

            _producerService.Delete(id);
            return NoContent();
        }
    }
}
