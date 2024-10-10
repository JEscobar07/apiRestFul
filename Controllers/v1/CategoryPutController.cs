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
    public class CategoryPutController : CategoryController
    {
        public CategoryPutController(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
    }
}