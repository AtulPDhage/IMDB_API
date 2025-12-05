using Dapper;
using DB_IMDB.Model.DataBase;
using DB_IMDB.Repository.Interface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DB_IMDB.Repository
{
    public class MovieRepository : BaseRepository<Movies>, IMovieRepository
    {
        public MovieRepository(IOptions<ConnectionString> connectionString)
          : base(connectionString.Value.IMDBDB)
        {

        }

        public IEnumerable<Movies> GetAll()
        {
            const string query = @"
SELECT [Id],
       [Name],
       [YearOfRelease],
       [Plot],
       [ProducerId],
       [Poster]
FROM [Movies] (NOLOCK)";

            return  GetAll(query);
           
        }
        public Movies GetById(int id)
        {
            const string query = @"
SELECT [Id],
       [Name],
       [YearOfRelease],
       [Plot],
       [ProducerId],
       [Poster]
FROM [Movies] (NOLOCK)
WHERE Id= @Id";

            return  GetById(query, new { Id = id });

          

        }
        public async Task Add(Movies movie,string actorIds, string genreIds)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("usp_AddMovie", new
            {
                movie.Name,
                movie.YearOfRelease,
                movie.Plot,
                movie.Poster,
                movie.ProducerId,
                ActorIds = actorIds,
                GenreIds = genreIds
            }, commandType: CommandType.StoredProcedure);

        }

        public async Task Update(int movieId, Movies movie, string actorIds, string genreIds)
        {
            using var connection = new SqlConnection(_connectionString);
           await connection.ExecuteAsync("usp_UpdateMovie", new
            {
                MovieId = movieId,
                movie.Name,
                movie.YearOfRelease,
                movie.Plot,
                movie.Poster,
                movie.ProducerId,
                ActorIds = actorIds,
                GenreIds = genreIds
            }, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Movies
WHERE Id = @Id";
            Execute(query, new { Id = id });
        }

    }
}
