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
    public class ProductDeleteController : ProductController
    {
        public ProductDeleteController(IProductRepository productRepository) : base(productRepository)
        {
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete products",
            Description = "Delete products in my system by id "
        )]
        [SwaggerResponse(200, "Return messagge")]
        [SwaggerResponse(404, "no products found")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {

            if (await productRepository.Delete(id) == true)
            {
                return Ok("The product was delete successfully");
            }
            else
            {
                return NotFound($"The product with id {id} wasn't found");
            }
        }
    }
}