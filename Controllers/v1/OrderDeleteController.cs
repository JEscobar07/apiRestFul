using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiRestFul.Models;
using apiRestFul.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apiRestFul.Controllers.v1
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderDeleteController : OrderController
    {
        public OrderDeleteController(IOrderRepository orderRepository) : base(orderRepository)
        {
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Order",
            Description = "Delete orders in my system by id "
        )]
        [SwaggerResponse(200, "Return messagge")]
        [SwaggerResponse(404, "no orders found")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {

            if (await orderRepository.Delete(id) == true)
            {
                return Ok("The order was delete successfully");
            }
            else
            {
                return NotFound($"The order with id {id} wasn't found");
            }
        }
    }
}