using ProductService.Models;

namespace ProductService.Services
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
    }
}