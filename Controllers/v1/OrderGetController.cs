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
    public class OrderGetController : OrderController
    {
        public OrderGetController(IOrderRepository orderRepository) : base(orderRepository)
        {
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "orders aggregates in my system",
        Description = "See all orders "
        )]
        [SwaggerResponse(200, "Return orders")]
        [SwaggerResponse(404, "no orders found")]
        public async Task<IActionResult> GetAllOrders()
        {
            var list = await orderRepository.GetAll();
            if (list == null || list.Count() == 0)
            {
                return NotFound("Lo sentimos pero no hay categorias disponibles en nuestro sistema");
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "orders by id",
            Description = "See orders by their ids"
        )]
        [SwaggerResponse(200, "Return orders")]
        [SwaggerResponse(404, "no orders found for the given id")]
        public async Task<IActionResult> GetIdOrders(int id)
        {
            var orderFound = await orderRepository.GetId(id);
            if (orderFound == null)
            {
                return NotFound($"Lo sentimos pero la orden con el id {id} no se encuentra disponible en nuestro sistema");
            }
            else
            {
                return Ok(orderFound);
            }
        }
    }
}