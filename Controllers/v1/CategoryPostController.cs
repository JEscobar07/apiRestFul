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
    public class CategoryPostController : CategoryController
    {
        public CategoryPostController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create categories",
            Description = "Create categories in my system "
        )]
        [SwaggerResponse(200, "Return messagge successfully")]
        [SwaggerResponse(400, "Return message about errors in the body of the DTO")]
        public async Task<IActionResult> PostCategory([FromBody] CategoryDTO categoryDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = new Category
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };

            if (category.Name != null)
            {

                await categoryRepository.Add(category);
                return Ok("Category save");
            }
            else
            {
                return BadRequest("Error in the attributes");
            }

        }
    }
}