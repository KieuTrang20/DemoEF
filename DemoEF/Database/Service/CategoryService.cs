using DemoEF.Database.Models;
using DemoEF.Database.DBContext;
using DemoEF.Database.IService;
namespace DemoEF.Database.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly Context _context;
        public CategoryService(Context context)
        {
            _context = context;
        }
        public List<Category> GetData()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public string Add(Category category)
        {

            category.CategoryStatus = true;
            try
            {
                _context.Categories.Add(category);
                return "Sucessful";
            }
            catch (Exception e)
            {
                return "Erorr" + e;
            }
        }
        public string Edit(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                return "Sucessful";
            }
            catch (Exception e)
            {

                return "Erorr" + e;
            }
        }

        public string Delete(Category category)
        {
            category.CategoryStatus = false;
            try
            {
                _context.Categories.Update(category);
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
