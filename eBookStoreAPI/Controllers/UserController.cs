using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;
using eBookStoreAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;
using Repositories.Implements;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository repository = new UserRepository();
        private IMapper Mapper { get; set; }
        public UserController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() => repository.GetUsers();

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var products = repository.GetUserById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDTO dto)
        {
            try
            {
                var User = Mapper.Map<User>(dto);
                repository.SaveUser(User);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<UserController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserDTO dto)
        {
            try
            {
                dto.UserId = id;
                var User = Mapper.Map<User>(dto);
                var UserTmp = repository.GetUserById(id);
                if (UserTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateUser(User);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<UserController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var User = repository.GetUserById(id);
                repository.DeleteUser(User);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Admin")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<User>> CheckAdmin()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("User")]
        [Authorize]
        public async Task<ActionResult<User>> CheckUser()
        {
            try
            {
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
