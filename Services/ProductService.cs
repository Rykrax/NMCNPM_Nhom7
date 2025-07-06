using NMCNPM_Nhom7.Repositories.Interfaces;
using NMCNPM_Nhom7.Services.Interfaces;
using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.DTOs;
using NMCNPM_Nhom7.Data;

namespace NMCNPM_Nhom7.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly AppDbContext _context;

        public ProductService(IProductRepository productRepo, AppDbContext context)
        {
            _productRepo = productRepo;
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<ProductModel?> GetProductByIdAsync(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }
        public async Task<ProductDetailModel?> GetProductDetailsAsync(int id)
        {
            return await _productRepo.GetProductDetailByIdAsync(id);
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

        public async Task<bool> UpdateProductAsync(int id, EditProductDTO model)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) return false;

            var productDetail = await _productRepo.GetProductDetailByIdAsync(model.IProductDetailID);
            if (productDetail == null) return false;

            product.SProductName = model.SProductName;
            product.ICategoryID = model.ICategoryID;

            productDetail.FImportPrice = model.FImportPrice;
            productDetail.FSellPrice = model.FImportPrice;
            productDetail.IQuantity = model.IQuantity;
            productDetail.IUnitID = model.IUnitID;
            productDetail.ISupplierID = model.ISupplierID;

            return await _productRepo.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var detail = await _productRepo.GetProductDetailByIdAsync(id);
            var product = await _productRepo.GetByIdAsync(detail?.IProductID ?? 0);

            if (product == null) return false;

            if (detail != null) _context.ProductDetails.Remove(detail);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}