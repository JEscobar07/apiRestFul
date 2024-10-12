using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiRestFul.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiRestFul.Controllers.v1
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        protected readonly IOrderRepository orderRepository ;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
    }
}