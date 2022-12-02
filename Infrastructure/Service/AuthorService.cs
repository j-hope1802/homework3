using System.Data;
using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.AuthorService

{
    public class AuthorService
    {
   private readonly DapperContext _context;
        private string? _connectionString;

        public AuthorService(DapperContext context)
    {
        _context = context;
    }

        public async Task <List<Author>> GetAuthor()
        {
             using (var conn = _context.CreateConnection())
            {
                var sql = $"SELECT first_name as FirstName,last_name as LastName,id as id FROM Author";

                var result =   await conn.QueryAsync<Author>(sql);
                return  result.ToList();
            }
        }

        public async Task <int>InsertAuthor(Author author)
        {
            using (var conn = _context.CreateConnection())
            {
              var sql =
                    $"insert into Author (First_Name,Last_Name) VALUES " +
                    $"('{author.FirstName}' ," +
                    $"'{author.LastName}' )" ;
                   
                var result = await conn.ExecuteAsync(sql);

                return result;
            }
        }

        public async Task<int> UpdateAuthor(Author author)
        {
 using (var conn = _context.CreateConnection())
            {
                var sql = 
                    $"UPDATE Author SET " +
                    $"First_Name = '{author.FirstName}', " +
                    $"Last_Name = '{author.LastName}' "+ 
                    $"WHERE id = {author.id}";

                var result = await conn.ExecuteAsync(sql);

                return result;
            }
        }

        public async Task<int> DeleteAuthor(int id)
        {
          using (var conn = _context.CreateConnection())
            {
                var sql = $"SELECT * FROM Author WHERE id = {id}";

                var result =await conn.ExecuteAsync(sql);

                return result;
            }
        }
    }
}