using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllAsync();
        Task<ProductModel?> GetByIdAsync(int id);
        Task<ProductModel?> GetByNameAsync(string name);
        Task<ProductDetailModel?> GetProductDetailByIdAsync(int id);
        Task<ProductModel> CreateAsync(ProductModel product);
        Task<bool> ExistsAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}