using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DemoEF.Database.IService;
using DemoEF.Database.Models;
using DemoEF.Controllers;
using DemoEF.ModelsController;
namespace DemoEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsServiceController _serviceController;

        public NewsController(NewsServiceController serviceController)
        {
            _serviceController = serviceController;
        }

        [HttpGet("Get")]
        public List<NewsView> GetNews()
        {

            try
            {
                return _serviceController.GetNewsForAll();
            }
            catch (Exception e)
            {

                return null;
            }
        }

        [HttpGet("GetOne/{name}")]
        public NewsView GetOne(string name)
        {
            try
            {

                NewsView newsForView = new NewsView();
                newsForView = _serviceController.GetNewsForAll()[_serviceController.GetNewsForAll().FindIndex(c => c.NewsName == name)];
                return newsForView;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(NewsView newsForView)
        {

            try
            {
                _serviceController.AddNews(newsForView);
                return Ok("Thêm Thành Công!");
            }
            catch (Exception e)
            {

                return BadRequest(" Erorr" + e);
            }
        }

        [HttpPut("Edit/{name}")]
        public IActionResult Edit(NewsView newsView)
        {

            try
            {
                _serviceController.EditNews(newsView);
                return Ok("Sửa Thành Công!");
            }
            catch (Exception e)
            {

                return BadRequest(" Erorr" + e);
            }
        }
        [HttpDelete("Delete/{name}")]
        public IActionResult Delete(NewsView newsView)
        {
            try
            {
                _serviceController.DeleteNews(newsView);
                return Ok("Xóa Thành Công!");
            }
            catch (Exception e)
            {

                return BadRequest(" Erorr" + e);
            }
        }
    }
}
