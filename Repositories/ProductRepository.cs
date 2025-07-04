using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.Repositories.Interfaces;

namespace NMCNPM_Nhom7.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductModel?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductModel?> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.SProductName == name);
        }

        public async Task<ProductModel> CreateAsync(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateAsync(int id, ProductModel product)
        {
            if (id != product.IProductID) return false;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(p => p.IProductID == id);
        }

        public async Task<List<ProductCategoryModel>> GetCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }
        public async Task<List<UnitModel>> GetUnitsAsync()
        {
            return await _context.Units.ToListAsync();
        }
        public async Task<List<SupplierModel>> GetSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }
    }
}