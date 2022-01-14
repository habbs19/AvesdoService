using AvesdoService.API.DTOs;
using AvesdoService.Core.Interfaces;
using AvesdoService.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AvesdoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository<OrderModel> _orderRepository;

        public OrderController(IOrderRepository<OrderModel> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // GET: api/<OrderController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<OrderModel>))]
        public async IAsyncEnumerable<OrderModel> GetOrders()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            
            foreach(var order in orders)
            {
                yield return order;
            }

        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderModel))]
        public async Task<ActionResult<OrderModel>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id);
            if (order != null)
            {
                return Ok(order);
            }
            return BadRequest(id);
        }

        // POST api/<OrderController>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderModel>> CreateOrder([FromBody] OrderDTO model)
        {
            if (ModelState.IsValid)
            {
                var order = new OrderModel
                {
                    CustomerID = model.CustomerID,
                    OrderDate = model.OrderDate
                };
                var newOrder = await _orderRepository.CreateOrderAsync(order);
                if(newOrder.OrderID != 0)
                {
                    return newOrder;
                }
                return StatusCode(StatusCodes.Status500InternalServerError, model);
            }
            return BadRequest(model);
        }

        // POST api/<OrderController>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrderItem([FromBody] OrderItemDTO orderItemModel)
        {
            if (ModelState.IsValid)
            {
                var model = new OrderItemModel
                {
                    OrderID = orderItemModel.OrderID,
                    ItemID = orderItemModel.ItemID,
                    Quantity = orderItemModel.Quantity
                };
                var result = await _orderRepository.AddOrderItem(model);
                if (result > 0)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, orderItemModel);
            }
            return BadRequest(orderItemModel);
        }
        
        // POST api/<OrderController>
        [HttpPost("[action]/{orderID}/{orderItemID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveOrderItem(int orderID,int orderItemID)
        {
            var result = await _orderRepository.RemoveOrderItem(orderID, orderItemID);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
          
        // DELETE api/<OrderController>/
        [HttpDelete("{orderID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrder(int orderID)
        {
            var result = await _orderRepository.DeleteOrderAsync(orderID);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<OrderController>/
        [HttpPut("{orderID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrderStatus(int orderID, int statusID)
        {
            var result = await _orderRepository.UpdateOrderStatus(orderID,statusID);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
