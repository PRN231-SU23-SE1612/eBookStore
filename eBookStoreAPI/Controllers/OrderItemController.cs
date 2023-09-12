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
    public class OrderItemController : ControllerBase
    {
        private IOrderItemRepository repository = new OrderItemRepository();
        private IMapper Mapper { get; set; }
        public OrderItemController(IMapper mapper)
        {
            Mapper = mapper;
        }

        // GET: api/OrderItems
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<OrderItem>>> GetOrderItems()
        {
            try
            {
                var OrderItems = repository.GetOrderItems();
                return Ok(OrderItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<OrderItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemById(int id)
        {
            try
            {
                var products = repository.GetOrderItemById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<OrderItemController>
        [HttpPost]
        public async Task<IActionResult> PostOrderItem([FromBody] OrderItemDTO dto)
        {
            try
            {
                var OrderItem = Mapper.Map<OrderItem>(dto);
                repository.SaveOrderItem(OrderItem);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<OrderItemController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutOrderItem(int id, [FromBody] OrderItemDTO dto)
        {
            try
            {
                dto.OrderItemId = id;
                var OrderItem = Mapper.Map<OrderItem>(dto);
                var OrderItemTmp = repository.GetOrderItemById(id);
                if (OrderItemTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateOrderItem(OrderItem);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<OrderItemController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            try
            {
                var OrderItem = repository.GetOrderItemById(id);
                repository.DeleteOrderItem(OrderItem);
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
