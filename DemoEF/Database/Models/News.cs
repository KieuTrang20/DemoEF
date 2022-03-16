using System.ComponentModel.DataAnnotations;
namespace DemoEF.Database.Models
{
    public class News
    {
        public Guid NewsId { get; set; }
        public Guid CategoryId { get; set; }
        [StringLength(200)]
        public string NewsName { get; set; }
        public string? NewsContent { get; set; }
        public string? NewsImage { get; set; }
        public bool NewsStatus { get; set; }
        public Category CategoryForView { get; set; }
    }
}
