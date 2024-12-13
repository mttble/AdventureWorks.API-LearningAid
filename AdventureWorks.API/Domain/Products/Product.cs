
namespace AdventureWorks.API.Domain.Products;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProductNumber { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Size { get; set; }
    public decimal? Weight { get; set; }
    public ProductCategory Category { get; set; }
}
