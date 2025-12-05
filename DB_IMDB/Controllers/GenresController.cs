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
    public class GenresController : ControllerBase
    {

        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var genre = _genreService.GetAll();
            return Ok(genre);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var genre =  _genreService.GetById(id);
            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Model.Request.Genres request)
        {
             _genreService.Add(request);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Model.Request.Genres request)
        {
            var existing =  _genreService.GetById(id);
            if (existing == null)
                return NotFound();

             _genreService.Update(id, request);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Model.Request.Genres request)
        {
            var existing =  _genreService.GetById(id);
            if (existing == null)
                return NotFound();

            _genreService.PartialUpdate(id, request);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing =  _genreService.GetById(id);
            if (existing == null)
                return NotFound();

             _genreService.Delete(id);
            return NoContent();
        }
    }
}
