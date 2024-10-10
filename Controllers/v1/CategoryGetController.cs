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
    [Route("api/v1/categories")]
    public class CategoryGetController : CategoryController
    {
        public CategoryGetController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "categories aggregates in my system",
            Description = "See all categories "
        )]
        [SwaggerResponse(200, "Return categories")]
        [SwaggerResponse(404, "no categories found")]
        public async Task<IActionResult> GetAllCategories()
        {
            var list = await categoryRepository.GetAll();
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
            Summary = "categories by id",
            Description = "See categories by their ids"
        )]
        [SwaggerResponse(200, "Return categories")]
        [SwaggerResponse(404, "no categories found for the given id")]
        public async Task<IActionResult> GetIdCategories(int id)
        {
            var categoryFound = await categoryRepository.GetId(id);
            if (categoryFound == null)
            {
                return NotFound($"Lo sentimos pero la categoria con el id {id} no se encuentra disponible en nuestro sistema");
            }
            else
            {
                return Ok(categoryFound);
            }
        }
    }
}