namespace DB_IMDB.Model.DataBase
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int? ProducerId { get; set; }
        public string Poster { get; set; }
    }
}
