using Microsoft.AspNetCore.Mvc;
using ScreeningTest.Entities;
using ScreeningTest.Services;

namespace ScreeningTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet(Name = "GetProduct")]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            if(products != null)
            {
                return Ok(products);
            }

            return NotFound();
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> Create(ProductModel model)
        {
            var id = await _productService.Create(model);
            return Ok(id);
        }
    }
}