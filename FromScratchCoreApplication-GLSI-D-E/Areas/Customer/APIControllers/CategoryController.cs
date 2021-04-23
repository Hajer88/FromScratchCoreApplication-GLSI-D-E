using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FromScratchCoreApplication_GLSI_D_E.Areas.Customer.Services;
using FromScratchCoreApplication_GLSI_D_E.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchCoreApplication_GLSI_D_E.Areas.Customer.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryServicecs categoryService;
        public CategoryController(ICategoryServicecs categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAllCategories();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategorie(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var categories = await categoryService.Create(category);
            return Ok(categories);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategorie(int id, Category category)
        {
            var categories = await categoryService.EditCategory(id, category);
            return Ok(categories);
        }

    }
}
