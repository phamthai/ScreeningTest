using ScreeningTest.Entities;

namespace ScreeningTest.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAll();
        Task<int> Create(ProductModel model);
    }
}
