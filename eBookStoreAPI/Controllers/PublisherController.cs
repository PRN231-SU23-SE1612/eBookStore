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
    public class PublisherController : ControllerBase
    {
        private IPublisherRepository repository = new PublisherRepository();
        private IMapper Mapper { get; set; }
        public PublisherController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/Publishers
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers() => repository.GetPublishers();

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisherById(int id)
        {
            try
            {
                var products = repository.GetPublisherById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<PublisherController>
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] PublisherDTO dto)
        {
            try
            {
                var Publisher = Mapper.Map<Publisher>(dto);
                repository.SavePublisher(Publisher);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<PublisherController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutPublisher(int id, [FromBody] PublisherDTO dto)
        {
            try
            {
                dto.PubId = id;
                var Publisher = Mapper.Map<Publisher>(dto);
                var PublisherTmp = repository.GetPublisherById(id);
                if (PublisherTmp == null)
                {
                    return NotFound();
                }
                repository.UpdatePublisher(Publisher);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<PublisherController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            try
            {
                var Publisher = repository.GetPublisherById(id);
                repository.DeletePublisher(Publisher);
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
