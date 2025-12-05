using DB_IMDB.Model.DataBase;
using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using DB_IMDB.Repository.Interface;
using DB_IMDB.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_IMDB.Service
{
    public class ProducerService:IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public void Add(Model.Request.Producers request)
        {
            var producer = new Model.DataBase.Producers
            {
                Name = request.Name,
                Bio = request.Bio,
                DOB = request.DOB.Value,
                Gender = request.Gender
            };
            _producerRepository.Add(producer);
        }

        public IEnumerable<Model.Response.Producers> GetAll()
        {
            var producer = _producerRepository.GetAll();
            return producer.Select(a => new Model.Response.Producers
            {
                Id = a.Id,
                Name = a.Name,
                Bio = a.Bio,
                DOB = a.DOB,
                Gender = a.Gender
            });

        }
        public Model.Response.Producers GetById(int id)
        {
            var producer = _producerRepository.GetById(id);
            if (producer == null)
            {
                return null;
            }
            return new Model.Response.Producers
            {
                Id = producer.Id,
                Name = producer.Name,
                Bio = producer.Bio,
                DOB = producer.DOB,
                Gender = producer.Gender
            };

        }
        public void Update(int id, Model.Request.Producers request)
        {
            var existing =  _producerRepository.GetById(id);
            if (existing != null)
            {
                existing.Name = request.Name;
                existing.Bio = request.Bio;
                existing.DOB = request.DOB.Value;
                existing.Gender = request.Gender;

                _producerRepository.Update(existing);
            }

        }

        public void PartialUpdate(int id, Model.Request.Producers request)
        {
            var existing =  _producerRepository.GetById(id);
            if (existing == null) return;

            if (request.Name != null)
                existing.Name = request.Name;

            if (request.Bio != null)
                existing.Bio = request.Bio;

            if (request.DOB.HasValue)
                existing.DOB = request.DOB.Value;

            if (request.Gender != null)
                existing.Gender = request.Gender;

            _producerRepository.Update(existing);
        }

        public void Delete(int id)
        {
            _producerRepository.Delete(id);
        }
    }
}
