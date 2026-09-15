using Microsoft.AspNetCore.Mvc;
using ProductsLabApi.Services;
using ProductsLabApi.Models;

namespace ProductsLabApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    // GET /api/products
    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all products");

        return Ok(_productService.GetAll());
    }

    // GET /api/products/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetById(id);

        if (product == null)
        {
            _logger.LogWarning("Product with ID {ProductId} was not found", id);

            return NotFound();
        }

        _logger.LogInformation("Product with ID {ProductId} was found", id);

        return Ok(product);
    }

    // POST /api/products
    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            return BadRequest("Name обязателен.");
        }

        var created = _productService.Add(product);

        _logger.LogInformation("Product {ProductName} was created", created.Name);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // DELETE /api/products/{id} -- дополнительное задание: обработка исключения с LogError
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id должен быть положительным числом.");
            }

            var deleted = _productService.Delete(id);

            if (!deleted)
            {
                _logger.LogWarning("Product with ID {ProductId} was not found", id);

                return NotFound();
            }

            _logger.LogInformation("Product with ID {ProductId} was deleted", id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while processing product with ID {ProductId}", id);

            return BadRequest("Некорректный запрос на удаление товара.");
        }
    }
}
