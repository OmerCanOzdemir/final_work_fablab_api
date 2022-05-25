using AutoMapper;
using business_logic.services.interfaces;
using data.models.entities;
using data.models.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
 
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<CategoryViewModel> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [HttpPost]
        public ActionResult<CategoryViewModel> Create(Category category)
        {
            return _categoryService.Create(category);
        }
        [HttpPut("{id}")]
        public ActionResult<CategoryViewModel> Update(Guid id, Category category)
        {
            
            return _categoryService.Update(id,category);
        }

        [HttpGet("{name}")]
        public ActionResult<CategoryViewModel> GetCategoryByName(string name)
        {
            
            return _categoryService.GetCategoryByName(name);
        }


        [HttpGet("byId/{id}")]
        public ActionResult<CategoryViewModel> GetCategoryById(Guid id)
        {

            return _categoryService.GetCategoryById(id);
        }
    }
}
