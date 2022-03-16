namespace DemoEF.ModelsController
{
    public class NewsView
    {
        private Guid newsId;
        private string category;
        private string newsName;
        private string newsContent;
        private string newsImage;


        public NewsView()
        {

        }

        public NewsView(Guid newsId, string category, string newsName, string newsContent, string newsImage)
        {
            this.newsId = newsId;
            this.category = category;
            this.newsName = newsName;
            this.newsContent = newsContent;
            this.newsImage = newsImage;

        }


        public Guid NewsId
        {
            get => newsId;
            set => newsId = value;
        }

        public string Category
        {
            get => category;
            set => category = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string NewsName
        {
            get => newsName;
            set => newsName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string NewsContent
        {
            get => newsContent;
            set => newsContent = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string NewsImage
        {
            get => newsImage;
            set => newsImage = value;
        }
    }
}
