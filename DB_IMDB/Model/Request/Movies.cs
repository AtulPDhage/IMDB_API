using DB_IMDB.Model.DataBase;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DB_IMDB.Model.Request
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int? ProducerId { get; set; }
        public IFormFile Poster { get; set; }

        public string ActorId { get; set; }
        public string GenreId { get; set; }
    }
}
