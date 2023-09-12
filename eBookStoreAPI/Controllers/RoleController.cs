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
    public class RoleController : ControllerBase
    {
        private IRoleRepository repository = new RoleRepository();
        private IMapper Mapper { get; set; }
        public RoleController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles() => repository.GetRoles();

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            try
            {
                var products = repository.GetRoleById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody] RoleDTO dto)
        {
            try
            {
                var Role = Mapper.Map<Role>(dto);
                repository.SaveRole(Role);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<RoleController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutRole(int id, [FromBody] RoleDTO dto)
        {
            try
            {
                dto.RoleId = id;
                var Role = Mapper.Map<Role>(dto);
                var RoleTmp = repository.GetRoleById(id);
                if (RoleTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateRole(Role);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<RoleController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var Role = repository.GetRoleById(id);
                repository.DeleteRole(Role);
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
