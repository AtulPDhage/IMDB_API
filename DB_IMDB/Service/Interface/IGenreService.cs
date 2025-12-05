using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Service.Interface
{
    public interface IGenreService
    {
        IEnumerable<Model.Response.Genres> GetAll();
        Model.Response.Genres GetById(int id);
        void Add(Model.Request.Genres request);
        void Update(int id, Model.Request.Genres request);
        void Delete(int id);
        void PartialUpdate(int id, Model.Request.Genres request);
    }
}
