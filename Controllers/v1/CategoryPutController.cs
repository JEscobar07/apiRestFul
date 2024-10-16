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
    [Route("api/v1/categories")]
    public class CategoryPutController : CategoryController
    {
        public CategoryPutController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update categories",
            Description = "Update categories in my system by id "
        )]
        [SwaggerResponse(200, "Return category updated")]
        [SwaggerResponse(404, "no categories found")]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] CategoryDTO categoryDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var category = new Category
                {
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description
                };
                Category categoryUpdate = await categoryRepository.Update(id, category);
                if (categoryUpdate != null)
                {
                    return Ok(categoryUpdate);
                }
                else
                {
                    return NotFound($"The category with id {id} wasn't found");
                }
            }
        }
    }
}