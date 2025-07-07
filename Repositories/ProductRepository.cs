using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
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

        public async Task<ProductDetailModel?> GetProductDetailByIdAsync(int id)
        {
            return await _context.ProductDetails.FirstOrDefaultAsync(pd => pd.IProductID == id);
        }

        public async Task<ProductModel> CreateAsync(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(p => p.IProductID == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}