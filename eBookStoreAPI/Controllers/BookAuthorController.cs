using AutoMapper;
using Repositories;
using BusinessObjects;
using BusinessObjects.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repositories.Implements;

namespace eBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private IBookAuthorRepository repository = new BookAuthorRepository();
        private IMapper Mapper { get; set; }
        public BookAuthorController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/BookAuthors
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors() => repository.GetBookAuthors();

        // GET api/<BookAuthorController>/5
        [HttpGet("{BookId}/{AuthorId}")]
        public async Task<ActionResult<BookAuthor>> GetBookAuthorById(int BookId, int AuthorId)
        {
            try
            {
                var products = repository.GetBookAuthorById(BookId, AuthorId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<BookAuthorController>
        [HttpPost]
        public async Task<IActionResult> PostBookAuthor([FromBody] BookAuthorDTO dto)
        {
            try
            {
                var BookAuthor = Mapper.Map<BookAuthor>(dto);
                repository.SaveBookAuthor(BookAuthor);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<BookAuthorController>/Update/5/6
        [HttpPut("Update/{BookId}/{AuthorId}")]
        public async Task<IActionResult> PutBookAuthor(int BookId, int AuthorId, [FromBody] BookAuthorDTO dto)
        {
            try
            {
                dto.BookId = BookId;
                dto.AuthorId = AuthorId;
                var BookAuthor = Mapper.Map<BookAuthor>(dto);
                var BookAuthorTmp = repository.GetBookAuthorById(BookId, AuthorId);
                if (BookAuthorTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateBookAuthor(BookAuthor);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<BookAuthorController>/Delete/5/6
        [HttpDelete("Delete/{BookId}/{AuthorId}")]
        public async Task<IActionResult> DeleteBookAuthor(int BookId, int AuthorId)
        {
            try
            {
                var BookAuthor = repository.GetBookAuthorById(BookId, AuthorId);
                repository.DeleteBookAuthor(BookAuthor);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
