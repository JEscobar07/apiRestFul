using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.DTOs;
using apirestful.Models;
using apirestful.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apirestful.Controllers.v1
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductPostController : ProductController
    {
        public ProductPostController(IProductRepository productRepository) : base(productRepository)
        {
        }
        [HttpPost]
        [SwaggerOperation(
           Summary = "Create products",
           Description = "Create products in my system "
       )]
        [SwaggerResponse(200, "Return messagge successfully")]
        [SwaggerResponse(400, "Return message about errors in the body of the DTO")]
        public async Task<IActionResult> PostProduct([FromBody] ProductDTO productDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Stock = productDTO.Stock,
                IdCategory = productDTO.IdCategory
            };

            if (product.Name != null)
            {

                await productRepository.Add(product);
                return Ok("product save");
            }
            else
            {
                return BadRequest("Error in the attributes");
            }

        }
    }
}