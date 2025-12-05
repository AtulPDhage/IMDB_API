using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DB_IMDB.Model.DataBase;
using DB_IMDB.Model.Request;
using DB_IMDB.Model.Response;
using DB_IMDB.Repository.Interface;
using DB_IMDB.Service.Interface;
using Microsoft.VisualBasic;

namespace DB_IMDB.Service
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public void Add(Model.Request.Actors request)
        {
            var actor = new Model.DataBase.Actors
            {
                Name = request.Name,
                Bio = request.Bio,
                DOB = request.DOB.Value,
                Gender = request.Gender
            };
             _actorRepository.Add(actor); 
        }

        public IEnumerable<Model.Response.Actors> GetAll()
        {
            var actor =  _actorRepository.GetAll();
            return  actor.Select(a => new Model.Response.Actors
            {
                Id=a.Id,
                Name = a.Name,
                Bio = a.Bio,
                DOB = a.DOB,
                Gender = a.Gender
            });
           
        }
        public Model.Response.Actors GetById(int id)
        {
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                return null;
            }
            return new Model.Response.Actors
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                DOB = actor.DOB,
                Gender = actor.Gender
            };

        }
        public void Update(int id, Model.Request.Actors request)
        {
            var existing =  _actorRepository.GetById(id);
            if (existing != null)
            {
                existing.Name = request.Name;
                existing.Bio = request.Bio;
                existing.DOB = request.DOB.Value;
                existing.Gender = request.Gender;

                 _actorRepository.Update(existing);
            }

        }

        public void PartialUpdate(int id, Model.Request.Actors request)
        {
            var existing=  _actorRepository.GetById(id);
            if (existing == null) return;

            if (request.Name != null)
                existing.Name = request.Name;

            if (request.Bio != null)
                existing.Bio = request.Bio;

            if (request.DOB.HasValue)
                existing.DOB = request.DOB.Value;

            if (request.Gender != null)
                existing.Gender = request.Gender;

             _actorRepository.Update(existing);
        }

        public void Delete(int id)
        {
             _actorRepository.Delete(id);
        }
    }
}
