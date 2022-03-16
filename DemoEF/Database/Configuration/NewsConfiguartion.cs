using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DemoEF.Database.Models;
namespace DemoEF.Database.Configuration
{
    public class NewsConfiguartion : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");
            builder.HasKey(p => p.NewsId);
            builder.HasOne(p => p.CategoryForView)
                .WithMany(p => p.News);
        }
    }
}
