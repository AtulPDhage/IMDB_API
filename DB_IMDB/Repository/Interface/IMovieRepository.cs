using DB_IMDB.Model.DataBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Repository.Interface
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetAll();

        Movies GetById(int id);
        public Task Add(Movies movie,string actorId,string genreId);
        public Task Update(int movieId,Movies movie, string actorId, string genreId);
        void Delete(int id);
    }
}
