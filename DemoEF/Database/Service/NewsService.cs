using DemoEF.Database.Models;
using DemoEF.Database.DBContext;
using DemoEF.Database.IService;
namespace DemoEF.Database.Service
{
    public class NewsService : INewsService
    {
        private readonly Context _context;
        public NewsService(Context context)
        {
            _context = context;
        }
        public List<News> GetData()
        {
            try
            {
                return _context.Set<News>().ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string Add(News news)
        {

            news.NewsStatus = true;
            try
            {
                _context.Set<News>().Add(news);
                return "Sucessful";
            }
            catch (Exception e)
            {
                return "Erorr" + e;
            }
        }

        public string Edit(News news)
        {
            try
            {
                _context.Set<News>().Update(news);
                return "Sucessful";
            }
            catch (Exception e)
            {

                return "Erorr" + e;
            }
        }

        public string Delete(News news)
        {
            news.NewsStatus = false;
            try
            {
                _context.Set<News>().Update(news);
                return "Sucessful";
            }
            catch (Exception e)
            {
                return "Erorr" + e;
            }
        }

        public string Save()
        {
            try
            {
                _context.SaveChanges();
                return "Sucessful";
            }
            catch (Exception e)
            {
                return "Erorr" + e;
            }
        }
    }
}
