using DemoEF.Database.Models;
namespace DemoEF.Database.IService
{
    public interface INewsService
    {
        public List<News> GetData();
        public string Add(News news);
        public string Edit(News news);
        public string Delete(News news);
        public string Save();
    }
}
