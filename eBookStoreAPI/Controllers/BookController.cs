using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repositories;
using Repositories.Implements;

namespace eBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository repository = new BookRepository();
        private IMapper Mapper { get; set; }
        public BookController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            try
            {
                var books = repository.GetBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            try
            {
                var products = repository.GetBookById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] BookDTO dto)
        {
            try
            {
                var Book = Mapper.Map<Book>(dto);
                repository.SaveBook(Book);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<BookController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody] BookDTO dto)
        {
            try
            {
                dto.BookId = id;
                var Book = Mapper.Map<Book>(dto);
                var BookTmp = repository.GetBookById(id);
                if (BookTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateBook(Book);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<BookController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var Book = repository.GetBookById(id);
                repository.DeleteBook(Book);
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
