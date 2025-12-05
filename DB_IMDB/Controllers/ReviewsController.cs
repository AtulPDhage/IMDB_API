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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var genre = _reviewService.GetAll();
            return Ok(genre);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _reviewService.GetById(id);
            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Model.Request.Reviews request)
        {
            _reviewService.Add(request);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Model.Request.Reviews request)
        {
            var existing =_reviewService.GetById(id);
            if (existing == null)
                return NotFound();

            _reviewService.Update(id, request);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Model.Request.Reviews request)
        {
            var existing = _reviewService.GetById(id);
            if (existing == null)
                return NotFound();

            _reviewService.PartialUpdate(id, request);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _reviewService.GetById(id);
            if (existing == null)
                return NotFound();

            _reviewService.Delete(id);
            return NoContent();
        }
    }
}
