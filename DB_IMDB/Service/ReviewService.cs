using DB_IMDB.Model.DataBase;
using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using DB_IMDB.Repository.Interface;
using DB_IMDB.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_IMDB.Service
{
    public class ReviewService:IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void Add(Model.Request.Reviews request)
        {
            var review = new Model.DataBase.Reviews
            {
                Message = request.Message,
                MovieId = request.MovieId,
            };
            _reviewRepository.Add(review);
        }

        public IEnumerable<Model.Response.Reviews> GetAll()
        {
            var review = _reviewRepository.GetAll();
            return review.Select(a => new Model.Response.Reviews
            {
                Id = a.Id,
               Message=a.Message,
               MovieId = a.MovieId,
            });

        }
        public Model.Response.Reviews GetById(int id)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
            {
                return null;
            }
            return new Model.Response.Reviews
            {
                Id = review.Id,
                Message= review.Message,
                MovieId = review.MovieId,
            };

        }
        public void Update(int id, Model.Request.Reviews request)
        {
            var existing = _reviewRepository.GetById(id);
            if (existing != null)
            {
                existing.Message = request.Message;
                existing.MovieId = request.MovieId;

                _reviewRepository.Update(existing);
            }

        }

        public void PartialUpdate(int id, Model.Request.Reviews request)
        {
            var existing = _reviewRepository.GetById(id);
            if (existing == null) return;

            if (request.Message != null)
                existing.Message = request.Message;
            if(request.MovieId != null)
                existing.MovieId = request.MovieId;


            _reviewRepository.Update(existing);
        }

        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }
    }
}
