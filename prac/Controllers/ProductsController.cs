using Microsoft.AspNetCore.Mvc;
using ProductsApi.Services;

namespace ProductsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService service, ILogger<ProductsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    // GET /api/products
    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all products");

        return Ok(_service.GetAll());
    }

    // GET /api/products/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetById(id);

        if (product == null)
        {
            _logger.LogWarning("Product with ID {ProductId} was not found", id);

            return NotFound();
        }

        _logger.LogInformation("Product with ID {ProductId} was found", id);

        return Ok(product);
    }
}
