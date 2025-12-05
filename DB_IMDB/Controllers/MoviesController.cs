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
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var actor = _movieService.GetAll();
            return Ok(actor);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var actor = _movieService.GetById(id);
            if (actor == null)
                return NotFound();

            return Ok(actor);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Add([FromForm] Model.Request.Movies request)
        {
            _movieService.Add(request);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public IActionResult Update(int id, [FromForm] Model.Request.Movies request)
        {
            var existing = _movieService.GetById(id);
            if (existing == null)
                return NotFound();

             _movieService.Update(id, request);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Model.Request.Movies request)
        {
            var existing =  _movieService.GetById(id);
            if (existing == null)
                return NotFound();

             _movieService.PartialUpdate(id, request);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _movieService.GetById(id);
            if (existing == null)
                return NotFound();

            _movieService.Delete(id);
            return NoContent();
        }
    }
}
