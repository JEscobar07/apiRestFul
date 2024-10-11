using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.DTOs;
using apirestful.Models;
using apirestful.Repositories;
using Microsoft.AspNetCore.Mvc;

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