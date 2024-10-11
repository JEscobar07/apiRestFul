using apirestful.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Delete categories",
            Description = "Delete categories in my system by id "
        )]
        [SwaggerResponse(200, "Return messagge")]
        [SwaggerResponse(404, "no categories found")]
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