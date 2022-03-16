using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoEF.Database.IService;
using DemoEF.Database.Models;
using DemoEF.ModelsController;
using Category = DemoEF.Database.Models.Category;
namespace DemoEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsServiceController
    {
        private readonly ICategoryService _categoryService;
        private readonly INewsService _newsService;
        private List<Category> _lstCategories;
        private List<News> _lstNews;
        private List<NewsView> _lstNewsViews;

        public NewsServiceController(ICategoryService categoryService, INewsService newsService)
        {
            _categoryService = categoryService;
            _newsService = newsService;
            GetListCategories();
            GetListNews();
        }

        public List<Category> GetListCategories()
        {
            _lstCategories = new List<Category>();
            _lstCategories = _categoryService.GetData().Where(c => c.CategoryStatus == true).ToList();
            return _lstCategories;
        }

        public List<News> GetListNews()
        {
            _lstNews = new List<News>();
            _lstNews = _newsService.GetData().Where(c => c.NewsStatus == true).ToList();
            return _lstNews;
        }

        public List<NewsView> GetNewsForAll()
        {
            GetListCategories();
            GetListNews();
            _lstNewsViews = new List<NewsView>();
            var listNewsTemp = from news in _lstNews
                               join
                                   category in _lstCategories on news.CategoryId equals category.CategoryId
                               select new
                               {
                                   NewsID = news.NewsId,
                                   NewName = news.NewsName,
                                   CategoryOfNews = category.CategoryName,
                                   NewContent = news.NewsContent,
                                   NewImage = news.NewsImage
                               };
            foreach (var x in listNewsTemp)
            {
                NewsView news = new NewsView(x.NewsID, x.CategoryOfNews, x.NewName, x.NewContent, x.NewImage);
                _lstNewsViews.Add(news);
            }
            return _lstNewsViews;
        }

        public string AddNews(NewsView newsView)
        {
            GetListCategories();
            GetListNews();
            News newInput = new News();
            newInput.NewsId = newsView.NewsId;
            newInput.NewsName = newsView.NewsName;
            newInput.NewsContent = newsView.NewsContent;
            newInput.NewsImage = newsView.NewsImage;

            if (_lstCategories.Any(c => c.CategoryName == newsView.Category))
            {
                newInput.CategoryId = _lstCategories[_lstCategories.FindIndex(c => c.CategoryName == newsView.Category)]
                    .CategoryId;

            }
            else
            {
                Category newCategory = new Category();
                newCategory.CategoryName = newsView.NewsName;
                _categoryService.Add(newCategory);
            }

            return _newsService.Add(newInput) + "  " + _categoryService.Save();

        }

        public string EditNews(NewsView newsView)
        {
            GetListCategories();
            GetListNews();
            News newInput = new News();
            newInput.NewsId = Guid.NewGuid();
            newInput.NewsName = newsView.NewsName;
            newInput.NewsContent = newsView.NewsContent;
            newInput.NewsImage = newsView.NewsImage;

            if (_lstCategories.Any(c => c.CategoryName == newsView.Category))
            {
                newInput.CategoryId = _lstCategories[_lstCategories.FindIndex(c => c.CategoryName == newsView.Category)]
                    .CategoryId;

            }
            else
            {
                Category newCategoryView = new Category();
                newCategoryView.CategoryId = Guid.NewGuid();
                newCategoryView.CategoryName = newsView.NewsName;
                newInput.CategoryId = newCategoryView.CategoryId;
                _categoryService.Add(newCategoryView);
            }

            return _newsService.Add(newInput) + " " + _categoryService.Save();
        }

        public string DeleteNews(NewsView newsView)
        {
            GetListNews();
            News news = new News();
            news = _lstNews.Find(c => c.NewsName == newsView.NewsName);
            return _newsService.Delete(news) + " " + _newsService.Save();
        }
    }
}
