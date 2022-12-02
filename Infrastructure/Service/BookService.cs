using System.Data;
using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.BookService

{
    
    public class BookService
    {
        private readonly DapperContext _context;
        private string? _connectionString;

        public BookService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorId>> GetBook()
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"select b.id, b.author_id as authorId , a.first_name as firstname ,a.last_name as lastname, b.book_name as bookname from book b join author a on b.author_id  = a.id";
                var result = await conn.QueryAsync<AuthorId>(sql);
                return result.ToList();
            }
        }
        public async Task<AuthorId> GetAuthorId(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"select b.id, b.author_id as authorId , a.first_name as firstname ,a.last_name as lastname, b.book_name as bookname from book b join author a on b.author_id  = a.id where b.id = {id}";


                var result = await conn.QuerySingleOrDefaultAsync<AuthorId>(sql, new { id });
                return result;

            }
        }

        public async Task<int> InsertBook(AuthorId authorId)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql =
              $"INSERT INTO Book (author_id,Book_Name) VALUES " +
              $"({authorId.authorId}, " +
              $"'{authorId.BookName}')";

                var result = await conn.ExecuteAsync(sql);

                return result;
            }
        }

        public async Task<int> UpdateBook(Book authorId)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql =
                    $"UPDATE Book SET "
                    + $"Book_Name = '{authorId.BookName}' " +
                     $"WHERE id = {authorId.id}";

                var result = await conn.ExecuteAsync(sql);

                return result;
            }
        }
        public async Task<int> DeleteBook(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"DELETE FROM Book WHERE id = {id}";

                var result = await conn.ExecuteAsync(sql);

                return result;
            }
        }

    }
}