using MediatR;
using ErrorOr;
using AdventureWorks.API.Domain.Products;
using AdventureWorks.API.Application.Common.Data;
using AdventureWorks.API.Application.Common.Settings;

namespace AdventureWorks.API.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler(IDbConnectionFactory dbConnectionFactory, ConnectionStrings connectionStrings) : IRequestHandler<GetProductsQuery, ErrorOr<List<Product>>>
{
    public async Task<ErrorOr<List<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        using var connection = dbConnectionFactory.CreateConnection(connectionStrings.AdventureWorks);
        //var query = "SELECT * FROM [SalesLT].[Product]";
        var query = @"
            SELECT P.ProductID, P.Name, P.ProductNumber, P.Color, P.StandardCost, P.ListPrice, P.Size, P.Weight, P.ProductCategoryID, PC.Name as ProductCategoryName
            FROM AdventureWorksLT2017.SalesLT.Product P
            INNER JOIN AdventureWorksLT2017.SalesLT.ProductCategory PC ON PC.ProductCategoryID = P.ProductCategoryID";
        var productQueryModels = await connection.QueryAsync<ProductQueryModel>(query);
        var products = productQueryModels.Select(p => new Product
        {
            Id = p.ProductId,
            Name = p.Name,
            ProductNumber = p.ProductNumber,
            Color = p.Color,
            StandardCost = p.StandardCost,
            ListPrice = p.ListPrice,
            Size = p.Size,
            Weight = p.Weight,
            Category = new ProductCategory
            {
                Id = p.ProductCategoryId,
                Name = p.ProductCategoryName
            }
        }).ToList();
        return products;
    }
}

public class ProductQueryModel
{
      public int ProductId { get; set; }
    public string Name { get; set; }
    public string ProductNumber { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Size { get; set; }
    public decimal? Weight { get; set; }
    public int ProductCategoryId { get; set; }
    public string ProductCategoryName { get; set; }
   

}
