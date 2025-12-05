using DB_IMDB.Model.DataBase;
using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using DB_IMDB.Repository.Interface;
using DB_IMDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DB_IMDB.Service
{
    public class MovieService:IMovieService
    {
        private readonly SupabaseService _supabaseService;
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGenreRepository _genreRepository;
        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository, IGenreRepository genreRepository, SupabaseService supabaseService)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
            _supabaseService = supabaseService;
        }

        public IEnumerable<Model.Response.Movies> GetAll()
        {
            var movies = _movieRepository.GetAll();
            var movieResponses = new List<Model.Response.Movies>();

            foreach (var movie in movies)
            {
                var actors = _actorRepository.GetActors(movie.Id);
                var genres = _genreRepository.GetGenres(movie.Id);

                movieResponses.Add(new Model.Response.Movies
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Plot = movie.Plot,
                    ProducerId = movie.ProducerId,
                    YearOfRelease = movie.YearOfRelease,
                    Poster = movie.Poster,
                    Actors = actors.ToList(),
                    Genres = genres.ToList()
                });

            }
            return movieResponses;
        }
        public void Add(Model.Request.Movies request)
        {
            string posterUrl = null;

            if (request.Poster != null && request.Poster.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(request.Poster.FileName);
                var filePath = Path.Combine(Path.GetTempPath(), fileName);

              
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    request.Poster.CopyTo(stream);
                }

              
                posterUrl = _supabaseService.UploadPoster(filePath, fileName);

                File.Delete(filePath);
            }
            var movie = new Model.DataBase.Movies
            {
                Name = request.Name,
                YearOfRelease = request.YearOfRelease,
                Plot = request.Plot,
                Poster = posterUrl,
                ProducerId = request.ProducerId
                
            };


             _movieRepository.Add(movie, request.ActorId, request.GenreId);
        }

        public Model.Response.Movies GetById(int id)
        {
            var movie =  _movieRepository.GetById(id);
            if (movie == null)
            {
                return null;
            }

            var actors = _actorRepository.GetActors(movie.Id);
            var genres = _genreRepository.GetGenres(movie.Id);
            return new Model.Response.Movies
            {
                Id = movie.Id,
                Name = movie.Name,
                Plot = movie.Plot,
                ProducerId = movie.ProducerId,
                YearOfRelease = movie.YearOfRelease,
                Poster = movie.Poster,
                Actors = actors.ToList(),
                Genres = genres.ToList()
            };
        }
        public void Update(int id, Model.Request.Movies request)
        {
            string posterUrl = null;

            if (request.Poster != null && request.Poster.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(request.Poster.FileName);
                var filePath = Path.Combine(Path.GetTempPath(), fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    request.Poster.CopyToAsync(stream);
                }

              
                posterUrl = _supabaseService.UploadPoster(filePath, fileName);

                
                File.Delete(filePath);
            }
            else
            {
          
                var existingMovie =  _movieRepository.GetById(id);
                posterUrl = existingMovie?.Poster;
            }

            var movie = new Model.DataBase.Movies
            {
                Id = id,
                Name = request.Name,
                YearOfRelease = request.YearOfRelease,
                Plot = request.Plot,
                Poster = posterUrl,
                ProducerId = request.ProducerId,
            };

            string actorIds = string.Join(",", request.ActorId);
            string genreIds = string.Join(",", request.GenreId);

            _movieRepository.Update(id, movie, actorIds, genreIds);
        }

        public void PartialUpdate(int id, Model.Request.Movies request)
        {
         
            var existingMovie = _movieRepository.GetById(id);
            if (existingMovie == null)
            {
                throw new Exception("Movie not found");
            }

            string posterUrl = existingMovie.Poster;

            
            if (request.Poster != null && request.Poster.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(request.Poster.FileName);
                var filePath = Path.Combine(Path.GetTempPath(), fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    request.Poster.CopyTo(stream);
                }

                posterUrl = _supabaseService.UploadPoster(filePath, fileName);

                File.Delete(filePath); 
            }

            
            if (request.Name != null)
                existingMovie.Name = request.Name;

            if (request.YearOfRelease.HasValue)
                existingMovie.YearOfRelease = request.YearOfRelease.Value;

            if (request.Plot != null)
                existingMovie.Plot = request.Plot;

            existingMovie.Poster = posterUrl;

            if (request.ProducerId.HasValue)
                existingMovie.ProducerId = request.ProducerId.Value;

       
            string actorIds = request.ActorId != null ? string.Join(",", request.ActorId) : null;
            string genreIds = request.GenreId != null ? string.Join(",", request.GenreId) : null;

           
            _movieRepository.Update(id, existingMovie, actorIds, genreIds);
        }
        public void Delete(int id)
        {
             _movieRepository.Delete(id);
        }
        

    }
}
