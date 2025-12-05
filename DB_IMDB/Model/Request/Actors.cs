using System;

namespace DB_IMDB.Model.Request
{
    public class Actors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
    }
}
