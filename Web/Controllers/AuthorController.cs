using Domain.Dtos;
using Infrastructure.AuthorService;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController
    {
       
        private AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService =  authorService;
        }

        
        [HttpGet]
        public async  Task<List<Author>> GetAuthor()
        {
            return await _authorService.GetAuthor();
        }
        [HttpPost("Insert")]
        public async Task <int>InsertAuthor(Author author)
        {
            return await _authorService.InsertAuthor(author);
        }

        [HttpPut]
        public async Task<int> UpdateAuthor(Author author)
        {
            return await _authorService.UpdateAuthor(author);
        }

      

       [HttpDelete]
        public async Task<int> DeleteAuthor(int id)
        {
            return await _authorService.DeleteAuthor(id);
        }
       
    }

    }

