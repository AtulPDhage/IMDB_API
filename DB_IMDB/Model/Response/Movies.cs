using DB_IMDB.Model.DataBase;
using System.Collections.Generic;

namespace DB_IMDB.Model.Response
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<Actors> Actors { get; set; }
        public List<Genres> Genres { get; set; }
        public string Producer { get; set; }
        public string Poster { get; set; }
        public int? ProducerId { get; set; }
    }
}
