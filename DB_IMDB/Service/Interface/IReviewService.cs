using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Service.Interface
{
    public interface IReviewService
    {
        IEnumerable<Model.Response.Reviews> GetAll();
        Model.Response.Reviews GetById(int id);
        void Add(Model.Request.Reviews request);
        void Update(int id, Model.Request.Reviews request);
        void Delete(int id);
        void PartialUpdate(int id, Model.Request.Reviews request);
    }
}
