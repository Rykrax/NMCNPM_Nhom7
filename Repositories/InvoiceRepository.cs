using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.DTOs;
using NMCNPM_Nhom7.Repositories.Interfaces;

namespace NMCNPM_Nhom7.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<InvoiceModel> CreateInvoiceAsync(InvoiceModel invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
    }
}