using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Service.Interface
{
    public interface IProducerService
    {
        IEnumerable<Model.Response.Producers> GetAll();
        Model.Response.Producers GetById(int id);
        void Add(Model.Request.Producers request);
        void Update(int id, Model.Request.Producers request);
        void Delete(int id);
        void PartialUpdate(int id, Model.Request.Producers request);
    }
}
