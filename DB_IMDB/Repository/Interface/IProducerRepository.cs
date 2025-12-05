using DB_IMDB.Model.DataBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Repository.Interface
{
    public interface IProducerRepository
    {
        IEnumerable<Producers> GetAll();

        Producers GetById(int id);
        void Add(Producers producer);
        void Update(Producers producer);
        void Delete(int id);
    }
}
