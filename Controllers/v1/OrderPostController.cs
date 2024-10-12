using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;
using apiRestFul.Controllers.v1;
using apiRestFul.DTOs;
using apiRestFul.Models;
using apiRestFul.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apiRestFul.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderPostController : OrderController
    {
        public OrderPostController(IOrderRepository orderRepository) : base(orderRepository)
        {
        }

        [HttpPost]
        [SwaggerOperation(
           Summary = "Create orders",
           Description = "Create orders in my system "
       )]
        [SwaggerResponse(200, "Return messagge successfully")]
        [SwaggerResponse(400, "Return message about errors in the body of the DTO")]
        public async Task<IActionResult> PostProduct([FromBody] OrderDTO orderDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (orderDTO.Date != null && orderDTO.Name != null)
            {
                var customer = new Customer
                {
                    Name = orderDTO.Name,
                    Address = orderDTO.Address,
                    NumberContact = orderDTO.NumberContact
                };

                await orderRepository.AddCustomer(customer);

                var order = new Order
                {
                    Date = DateTime.Today,
                    IdCustomer = customer.Id
                };

                await orderRepository.AddOrder(order);
                return Ok("Order save");
            }
            else
            {
                return BadRequest("Error in the attributes");
            }
        }

    }
}