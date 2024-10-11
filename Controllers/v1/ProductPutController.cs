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
    public class ProductPutController : ProductController
    {
        public ProductPutController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
           Summary = "Update products",
           Description = "Update products in my system by id "
       )]
        [SwaggerResponse(200, "Return Product updated")]
        [SwaggerResponse(404, "no products found")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] ProductDTO productDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var product = new Product
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Price = productDTO.Price,
                    Stock = productDTO.Stock,
                    IdCategory = productDTO.IdCategory
                };
                Product productUpdate = await productRepository.Update(id, product);
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