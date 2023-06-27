namespace AutoMapperLibary.UI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public string GetFullName()
    {
        return ProductName + Price + Category.CategoryName;
    }

    public decimal? Prices()
    {
        return Price;
    }
}
