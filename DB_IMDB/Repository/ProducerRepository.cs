using DB_IMDB.Model.DataBase;
using DB_IMDB.Repository.Interface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Repository
{
    public class ProducerRepository:BaseRepository<Producers>,IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionString> connectionString)
           : base(connectionString.Value.IMDBDB)
        {

        }

        public IEnumerable<Producers> GetAll()
        {
            const string query = @"
SELECT [Id]
    , [Name]
    , [Bio]
    , [DOB]
    , [Gender]
FROM [Producers] (NOLOCK)";

            return GetAll(query);


        }
        public Producers GetById(int id)
        {
            const string query = @"
SELECT [Id]
    , [Name]
    , [Bio]
    , [DOB]  
    , [Gender]
FROM [Producers] (NOLOCK)
WHERE Id= @Id";

            return GetById(query, new { Id = id });

          

        }
        public void Add(Producers actor)
        {
            const string query = @"
INSERT INTO Producers (
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

        public void Update(Producers actor)
        {
            const string query = @"
UPDATE Producers
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
FROM Producers
WHERE Id = @Id";
            Execute(query, new { Id = id });
        }


    }
}
