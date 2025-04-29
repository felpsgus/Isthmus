using Isthmus.Application.Products;
using Isthmus.Application.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace Isthmus.Api.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductModel productModel)
    {
        var result = await _productService.CreateProduct(productModel);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductModel productModel)
    {
        var result = await _productService.UpdateProduct(productModel);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(
        [FromQuery] string? searchTerm,
        [FromQuery] bool? isActive,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 100)
    {
        var result = await _productService.GetProductsAsync(searchTerm, isActive, page, pageSize);
        return Ok(result);
    }
}