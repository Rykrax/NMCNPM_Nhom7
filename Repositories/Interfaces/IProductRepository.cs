using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllAsync();
        Task<ProductModel?> GetByIdAsync(int id);
        Task<ProductModel?> GetByNameAsync(string name);
        Task<ProductModel> CreateAsync(ProductModel product);
        Task<bool> UpdateAsync(int id, ProductModel product);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<List<ProductCategoryModel>> GetCategoriesAsync();
        Task<List<UnitModel>> GetUnitsAsync();
        Task<List<SupplierModel>> GetSuppliersAsync();
    }
}