namespace DB_IMDB.Model.DataBase
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int? MovieId { get; set; }
    }
}
