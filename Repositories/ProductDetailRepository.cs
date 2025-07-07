using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.DTOs;
using NMCNPM_Nhom7.Repositories.Interfaces;

namespace NMCNPM_Nhom7.Repositories
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly AppDbContext _context;

        public ProductDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDetailDTO>> SearchByProductNameAsync(string keyword)
        {
            return await _context.ProductDetails
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .Include(p => p.Unit)
                .Where(p => p.Product.SProductName.Contains(keyword) || p.IProductDetailID.ToString().Contains(keyword))
                .Select(p => new ProductDetailDTO
                {
                    ProductDetailID = p.IProductDetailID,
                    ProductName = p.Product.SProductName,
                    Quantity = p.IQuantity,
                    ImportPrice = p.FImportPrice,
                    SellPrice = p.FSellPrice,
                    UnitName = p.Unit.SUnitName
                })
                .Take(10)
                .ToListAsync();
        }
    }
}