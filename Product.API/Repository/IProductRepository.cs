using Product.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public interface IProductRepository
    {
       
        Task<ProductModel> searchProductByIdAsync(int ProductId);
        Task<ProductModel> searchProductByNameAsync(string ProductName);
        Task<int> addProductRatingAsync(int ProductId, int Rating);
       
    }
}
