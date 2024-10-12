using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apirestful.Controllers.v1
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductGetController : ProductController
    {
        public ProductGetController(IProductRepository productRepository) : base(productRepository)
        {
        }
        [HttpGet]
        [SwaggerOperation(
        Summary = "products aggregates in my system",
        Description = "See all products "
    )]
        [SwaggerResponse(200, "Return products")]
        [SwaggerResponse(404, "no products found")]
        public async Task<IActionResult> GetAllProducts()
        {
            var list = await productRepository.GetAll();
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
            Summary = "products by id",
            Description = "See products by their ids"
        )]
        [SwaggerResponse(200, "Return products")]
        [SwaggerResponse(404, "no products found for the given id")]
        public async Task<IActionResult> GetIdproducts(int id)
        {
            var productFound = await productRepository.GetId(id);
            if (productFound == null)
            {
                return NotFound($"Lo sentimos pero el producto con el id {id} no se encuentra disponible en nuestro sistema");
            }
            else
            {
                return Ok(productFound);
            }
        }
    }
}