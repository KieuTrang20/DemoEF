namespace DemoEF.ModelsController
{
    public class CategoryView
    {
        private Guid categoryId;

        private string categoryName;

        private string categoryDescription;

        public CategoryView()
        {

        }

        public CategoryView(Guid categoryId, string categoryName, string categoryDescription)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
            this.categoryDescription = categoryDescription;
        }

        public Guid CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        public string CategoryName
        {
            get => categoryName;
            set => categoryName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string CategoryDescription
        {
            get => categoryDescription;
            set => categoryDescription = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
