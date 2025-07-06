using NMCNPM_Nhom7.DTOs;
using Microsoft.CodeAnalysis.Differencing;

namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel?> GetProductByIdAsync(int id);
        Task<ProductDetailModel?> GetProductDetailsAsync(int id);
        Task<ProductModel> CreateProductAsync(ProductModel product);
        Task<bool> UpdateProductAsync(int id, EditProductDTO model);
        Task<bool> DeleteProductAsync(int id);
    }
}