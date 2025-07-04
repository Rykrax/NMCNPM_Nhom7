using NMCNPM_Nhom7.Repositories.Interfaces;
using NMCNPM_Nhom7.Services.Interfaces;
using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<ProductModel?> GetProductByIdAsync(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            if (string.IsNullOrWhiteSpace(product.SProductName))
            {
                throw new ArgumentException("Tên sản phẩm không được để trống", nameof(product.SProductName));
            }
            return await _productRepo.CreateAsync(product);
        }

        public async Task<bool> UpdateProductAsync(int id, ProductModel product)
        {
            return await _productRepo.UpdateAsync(id, product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepo.DeleteAsync(id);
        }
        public async Task<IEnumerable<ProductCategoryModel>> GetProductCategoriesAsync()
        {
            return await _productRepo.GetCategoriesAsync();
        }
        public async Task<IEnumerable<UnitModel>> GetUnitsAsync()
        {
            return await _productRepo.GetUnitsAsync();
        }
        public async Task<IEnumerable<SupplierModel>> GetSuppliersAsync()
        {
            return await _productRepo.GetSuppliersAsync();
        }
    }
}