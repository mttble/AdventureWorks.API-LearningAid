namespace AdventureWorks.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;
using AdventureWorks.API.Application.Products.Queries.GetProducts;

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/api/v1/test")]
    public IActionResult Test()
    {
        return Ok("Controller working!");
    }

    [HttpGet("/api/v1/products")]
    public async Task<IActionResult> GetProducts()
    {
        var query = new GetProductsQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            products => Ok(products),
            errors => Problem(title: errors.First().Description)
        );
    }
}