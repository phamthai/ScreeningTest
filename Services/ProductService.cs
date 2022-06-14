using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScreeningTest.Entities;

namespace ScreeningTest.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApiContext context, IMapper mapper, ILogger<ProductService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            var products = await _context.Products
                .ToListAsync();

            if (products != null)
            {
                return _mapper.Map<List<ProductModel>>(products);
            }

            return null;
        }

        public async Task<int> Create(ProductModel model)
        {
            var product = _mapper.Map<Product>(model);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
