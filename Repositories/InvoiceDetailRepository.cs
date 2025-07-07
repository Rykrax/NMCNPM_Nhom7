using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.Repositories.Interfaces;

namespace NMCNPM_Nhom7.Repositories
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly AppDbContext _context;

        public InvoiceDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddInvoiceDetailsAsync(List<InvoiceDetailModel> details)
        {
            await _context.InvoiceDetails.AddRangeAsync(details);
            await _context.SaveChangesAsync();
        }
    }
}
