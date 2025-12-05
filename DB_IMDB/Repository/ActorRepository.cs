using System.Collections.Generic;
using DB_IMDB.Model.DataBase;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using Dapper;
using DB_IMDB.Repository.Interface;
using System.Threading.Tasks;

namespace DB_IMDB.Repository
{
    public class ActorRepository : BaseRepository<Actors>, IActorRepository
    {
        

        public ActorRepository(IOptions<ConnectionString>  connectionString)
            : base(connectionString.Value.IMDBDB)
        {

        }

        public IEnumerable<Actors> GetAll()
        {
            const string query = @"
SELECT [Id]
    , [Name]
    , [Bio]
    , [DOB]  
    , [Gender]
FROM [Actors] (NOLOCK)";

            return  GetAll(query);
           

        }
        public Actors GetById(int id)
        {
            const string query = @"
SELECT [Id]
    , [Name]
    , [Bio]
    , [DOB]  
    , [Gender]
FROM [Actors] (NOLOCK)
WHERE Id= @Id";

            return  GetById(query, new { Id = id });

          

        }
        public void Add(Actors actor)
        {
            const string query = @"
INSERT INTO Actors (
	Name
	,Bio
	,DOB
	,Gender
	)
VALUES (
	@Name
	,@Bio
	,@DOB
	,@Gender
	)";
            Execute(query, actor);
        }

        public void Update(Actors actor)
        {
            const string query = @"
UPDATE Actors
SET Name = @Name
	,Bio = @Bio
	,DOB = @DOB
	,Gender = @Gender
WHERE Id = @Id";

            Execute(query, actor);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Actors
WHERE Id = @Id";
             Execute(query, new { Id = id });
        }
        public IEnumerable<Model.Response.Actors> GetActors(int movieId)
        {
            var query = @"
SELECT a.Id
    , a.Name
    , a.Bio
    , a.DOB
    , a.Gender
FROM Actors a
INNER JOIN Actors_Movies am ON a.Id = am.ActorId
WHERE am.MovieId = @MovieId";

            using var connection = new SqlConnection(_connectionString); 
            return connection.Query<Model.Response.Actors>(query, new { MovieId = movieId });
        }


    }
}