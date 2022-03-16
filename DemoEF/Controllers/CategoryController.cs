using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoEF.Database.IService;
using DemoEF.Database.Models;
using DemoEF.Controllers;
using DemoEF.ModelsController;
using Category = DemoEF.Database.Models.Category;
namespace DemoEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServiceController _categoryController;


        public CategoryController(CategoryServiceController categoryController)
        {
            _categoryController = categoryController;
        }

        [HttpGet("Get")]
        public List<ModelsController.CategoryView> GetCategories()
        {
            return _categoryController.GetLstCategoryViews();
        }

        [HttpPost("Add")]
        public IActionResult AddNewCategory(CategoryView newCategoryView)
        {
            try
            {
                return Ok(_categoryController.AddCategory(newCategoryView));
            }
            catch (Exception e)
            {

                return BadRequest("Erorr" + e);
            }
        }

        [HttpPut("Edit/{name}")]
        public IActionResult Edit(CategoryView categoryViewEdited)
        {
            try
            {
                return Ok(_categoryController.EditCategory(categoryViewEdited));
            }
            catch (Exception e)
            {
                return BadRequest("Erorr" + e);
            }
        }

        [HttpDelete("Delete/{name}")]
        public IActionResult Delete(CategoryView categoryViewToDelete)
        {
            try
            {
                return Ok(_categoryController.DeleteCategory(categoryViewToDelete));
            }
            catch (Exception e)
            {
                return BadRequest("Erorr" + e);
            }
        }
    }
}
