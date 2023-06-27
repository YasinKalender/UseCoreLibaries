namespace AutoMapperLibary.UI.DTOS
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string NamePrice { get; set; }
        public string CategoryName { get; set; }
        public string ExampleCategoryName { get; set; }
        public string FullName { get; set; } //Entity içindeki metodu map yapmak için kullandım.. Entity içinden GetFullName diye tanımlarsak direk mapleme yapar.
        public decimal? ProductPrice { get; set; } //Entity içindeki metodu map yapmak için kullandım..
        public string CategoryCategoryName { get; set; } //Category tablosunda verilere direk erişebiliyoruz..
    }
}
