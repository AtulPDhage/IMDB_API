using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using DB_IMDB.Model.DataBase;

namespace DB_IMDB.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly string _connectionString;
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> GetAll(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query);
        }

        public T GetById(string query,object parameter)
        {
            using var connection = new SqlConnection(_connectionString);
      
            return  connection.QueryFirstOrDefault<T>(query, parameter);
        }
        public void Execute(string query, object parameter)
        {
            using var connection = new SqlConnection(_connectionString);
             connection.Execute(query, parameter);
        }


    }
}
