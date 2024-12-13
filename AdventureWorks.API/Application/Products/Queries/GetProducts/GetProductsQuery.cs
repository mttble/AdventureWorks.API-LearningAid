using MediatR;
using ErrorOr;
using AdventureWorks.API.Domain.Products;

namespace AdventureWorks.API.Application.Products.Queries.GetProducts;

public record GetProductsQuery : IRequest<ErrorOr<List<Product>>>;

