using DB_IMDB.Model.DataBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Repository.Interface
{
    public interface IGenreRepository
    {
        IEnumerable<Genres> GetAll();
        Genres GetById(int id);
        void Add(Genres genre);
        void Update(Genres genre);
        void Delete(int id);
        IEnumerable<Model.Response.Genres> GetGenres(int movieId);
    }

}
