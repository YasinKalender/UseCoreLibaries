namespace FluentValidation.UI.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
