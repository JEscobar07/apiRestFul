using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apirestful.Controllers.v1
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryDeleteController : CategoryController
    {
        public CategoryDeleteController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {

            if (await categoryRepository.Delete(id) == true)
            {
                return Ok("The category was delete successfully");
            }
            else
            {
                return NotFound($"The category with id {id} wasn't found");
            }
        }
    }
}   