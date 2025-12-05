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
    public class GenreService:IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void Add(Model.Request.Genres request)
        {
            var genre = new Model.DataBase.Genres
            {
                Name = request.Name
            };
            _genreRepository.Add(genre);
        }

        public IEnumerable<Model.Response.Genres> GetAll()
        {
            var genre = _genreRepository.GetAll();
            return genre.Select(a => new Model.Response.Genres
            {
                Id=a.Id,
                Name = a.Name
            });

        }
        public Model.Response.Genres GetById(int id)
        {
            var genre =  _genreRepository.GetById(id);
            if (genre == null)
            {
                return null;
            }
            return new Model.Response.Genres
            {
                Id = genre.Id,
                Name = genre.Name
            };

        }
        public void Update(int id, Model.Request.Genres request)
        {
            var existing =  _genreRepository.GetById(id);
            if (existing != null)
            {
                existing.Name = request.Name;

                _genreRepository.Update(existing);
            }

        }

        public void PartialUpdate(int id, Model.Request.Genres request)
        {
            var existing = _genreRepository.GetById(id);
            if (existing == null) return;

            if (request.Name != null)
                existing.Name = request.Name;


            _genreRepository.Update(existing);
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }
    }
}

