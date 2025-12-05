using Microsoft.Extensions.Options;
using DB_IMDB.Model.DataBase;


using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using DB_IMDB.Repository.Interface;

namespace DB_IMDB.Repository
{
    public class GenreRepository:BaseRepository<Genres>,IGenreRepository
    {
       
        public GenreRepository(IOptions<ConnectionString> connectionString)
           : base(connectionString.Value.IMDBDB)
        {

        }
        public IEnumerable<Genres> GetAll()
        {
            const string query = @"
SELECT [Id]
    , [Name]
FROM [Genres] (NOLOCK)";

            return GetAll(query);
        }

        public Genres GetById(int id)
        {
            const string query = @"
SELECT [Id]
    , [Name]
FROM [Genres] (NOLOCK)
WHERE Id= @Id";
            return GetById(query, new { id = id });
        }
        public void Add(Genres genre)
        {
            const string query = @"
INSERT INTO Genres (
	Name
	)
VALUES (
	@Name
	)";
            Execute(query, genre);
        }

        public void Update(Genres genre)
        {
            const string query = @"
UPDATE Genres
SET Name = @Name
WHERE Id = @Id";

             Execute(query, genre);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Genres
WHERE Id = @Id";
             Execute(query, new { Id = id });
        }

        public IEnumerable<Model.Response.Genres> GetGenres(int movieId)
        {
            var sql = @"
SELECT g.Id
    , g.Name
FROM Genres g
INNER JOIN Genres_Movies gm ON g.Id = gm.GenreId
WHERE gm.MovieId = @MovieId";

            using var connection = new SqlConnection(_connectionString);
            return  connection.Query<Model.Response.Genres>(sql, new { MovieId = movieId });
        }


    }
}
