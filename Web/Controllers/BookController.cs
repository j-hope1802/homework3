using Domain.Dtos;
using Infrastructure.BookService;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
      
        private BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService =  bookService;
        }

       
        [HttpGet("books")]
        public async  Task <List<AuthorId>> GetBook()
        {
            return await _bookService.GetBook();
        }
        [HttpPost("Insert")]
        public async Task<int> InsertBook(AuthorId authorId)
        {
            return await _bookService.InsertBook(authorId);
        }

        [HttpPut("Update")]
        public async Task<int> UpdateBook(Book authorId)
        {
            return   await _bookService.UpdateBook( authorId);
        }

    
               [HttpGet("Byid")]
        public async Task <AuthorId>   GetAuthorId(int id)
        {
            return await _bookService.GetAuthorId(id);
        }
             [HttpDelete]
         public async Task<int> DeleteBook(int id)
        {
            return await _bookService.DeleteBook(id);
        }
    }


    }

