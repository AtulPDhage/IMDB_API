using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Service.Interface
{
    public interface IMovieService
    {
        IEnumerable<Model.Response.Movies> GetAll();
        Model.Response.Movies GetById(int id);
        void Add(Model.Request.Movies request);
        void Update(int id, Model.Request.Movies request);
        void Delete(int id);

        void PartialUpdate(int id, Model.Request.Movies request);
    }
}
