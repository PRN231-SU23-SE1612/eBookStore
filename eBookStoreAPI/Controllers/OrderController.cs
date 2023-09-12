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
    public class OrderController : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();
        private IMapper Mapper { get; set; }
        public OrderController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            try
            {
                var Orders = repository.GetOrders();
                return Ok(Orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            try
            {
                var products = repository.GetOrderById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderDTO dto)
        {
            try
            {
                var Order = Mapper.Map<Order>(dto);
                repository.SaveOrder(Order);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<OrderController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] OrderDTO dto)
        {
            try
            {
                dto.OrderId = id;
                var Order = Mapper.Map<Order>(dto);
                var OrderTmp = repository.GetOrderById(id);
                if (OrderTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateOrder(Order);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<OrderController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var Order = repository.GetOrderById(id);
                repository.DeleteOrder(Order);
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
