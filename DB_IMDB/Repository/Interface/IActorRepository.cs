using System.Collections.Generic;
using System.Threading.Tasks;
using DB_IMDB.Model.DataBase;

namespace DB_IMDB.Repository.Interface
{
    public interface IActorRepository
    {
        IEnumerable<Actors> GetAll();

        Actors GetById(int id);
        void Add(Actors actor);
        void Update(Actors actor);
        void Delete(int id);
        IEnumerable<Model.Response.Actors> GetActors(int movieId);
    }
}
