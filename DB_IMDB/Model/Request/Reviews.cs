namespace DB_IMDB.Model.Request
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int? MovieId { get; set; }
    }
}
