using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiRestFul.DTOs;
using apiRestFul.Models;
using apiRestFul.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apiRestFul.Controllers.v1
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderPutController : OrderController
    {
        public OrderPutController(IOrderRepository orderRepository) : base(orderRepository)
        {
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
           Summary = "Update orders",
           Description = "Update orders in my system by id "
       )]
        [SwaggerResponse(200, "Return Product updated")]
        [SwaggerResponse(404, "no orders found")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] OrderDTO orderDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Order productUpdate = await orderRepository.Update(id, orderDTO);
                if (productUpdate != null)
                {
                    return Ok(productUpdate);
                }
                else
                {
                    return NotFound($"The category with id {id} wasn't found");
                }
            }
        }
    }
}