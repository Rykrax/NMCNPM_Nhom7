
namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel?> GetProductByIdAsync(int id);
        Task<ProductModel> CreateProductAsync(ProductModel product);
        Task<bool> UpdateProductAsync(int id, ProductModel product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductCategoryModel>> GetProductCategoriesAsync();
        Task<IEnumerable<UnitModel>> GetUnitsAsync();
        Task<IEnumerable<SupplierModel>> GetSuppliersAsync();
    }
}