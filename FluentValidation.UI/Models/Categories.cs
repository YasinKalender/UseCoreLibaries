namespace FluentValidation.UI.Models
{
    public class Categories
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public List<Products> Products { get; set; }
    }
}
