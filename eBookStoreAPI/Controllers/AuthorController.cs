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
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository repository = new AuthorRepository();
        private IMapper Mapper { get; set; }
        public AuthorController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            try
            {
                var books = repository.GetAuthors();
                return Ok(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            try
            {
                var products = repository.GetAuthorById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> PostAuthor([FromBody] AuthorDTO dto)
        {
            try
            {
                var Author = Mapper.Map<Author>(dto);
                repository.SaveAuthor(Author);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<AuthorController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutAuthor(int id, [FromBody] AuthorDTO dto)
        {
            try
            {
                dto.AuthorId = id;
                var Author = Mapper.Map<Author>(dto);
                var AuthorTmp = repository.GetAuthorById(id);
                if (AuthorTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateAuthor(Author);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<AuthorController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var Author = repository.GetAuthorById(id);
                repository.DeleteAuthor(Author);
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
