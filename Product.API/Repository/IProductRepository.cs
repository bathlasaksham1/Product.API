using Product.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int ProductId);
        Task<ProductModel> GetProductByNameAsync(string ProductName);
        Task<int> AddProductAsync(ProductModel productModel);
    }
}
