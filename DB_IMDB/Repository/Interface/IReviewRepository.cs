using DB_IMDB.Model.DataBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Repository.Interface
{
    public interface IReviewRepository
    {
        IEnumerable<Reviews> GetAll();

        Reviews GetById(int id);
        void Add(Reviews actor);
        void Update(Reviews actor);
        void Delete(int id);
    }
}
