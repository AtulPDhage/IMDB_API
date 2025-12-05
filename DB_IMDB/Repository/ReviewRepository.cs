using DB_IMDB.Model.DataBase;
using DB_IMDB.Repository.Interface;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_IMDB.Repository
{
    public class ReviewRepository:BaseRepository<Reviews>, IReviewRepository
    {
        public ReviewRepository(IOptions<ConnectionString> connectionString)
          : base(connectionString.Value.IMDBDB)
        {

        }

        public IEnumerable<Reviews> GetAll()
        {
            const string query = @"
SELECT [Id]
    , [Message]
    , [MovieId]
FROM [Reviews] (NOLOCK)";

            return GetAll(query);
     

        }
        public Reviews GetById(int id)
        {
            const string query = @"
SELECT [Id]
    , [Message]
    , [MovieId]
FROM [Reviews] (NOLOCK)
WHERE Id= @Id";

            return GetById(query, new { Id = id });

       

        }
        public void Add(Reviews actor)
        {
            const string query = @"
INSERT INTO Reviews (
	Message
	,MovieId
	)
VALUES (
	@Message
	,@MovieId
	)";
            Execute(query, actor);
        }

        public void Update(Reviews actor)
        {
            const string query = @"
UPDATE Reviews
SET Message = @Message
	,MovieId = @MovieId
WHERE Id = @Id";

            Execute(query, actor);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Reviews
WHERE Id = @Id";
            Execute(query, new { Id = id });
        }

    }
}
