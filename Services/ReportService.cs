using System.Linq;
using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.Services.Interfaces;

namespace NMCNPM_Nhom7.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReportDTO> GetReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            var invoicesQuery = _context.Invoices.AsQueryable();

            if (fromDate.HasValue)
                invoicesQuery = invoicesQuery.Where(i => i.DCreatedDate >= fromDate.Value);

            if (toDate.HasValue)
                invoicesQuery = invoicesQuery.Where(i => i.DCreatedDate <= toDate.Value);

            var totalRevenue = await invoicesQuery.AnyAsync()
                ? await invoicesQuery.SumAsync(i => i.FTotal)
                : 0;

            var totalInvoices = await invoicesQuery.CountAsync();

            var invoiceIds = await invoicesQuery.Select(i => i.IInvoiceID).ToListAsync();

            var topProducts = await _context.InvoiceDetails
                .Where(d => invoiceIds.Contains((int)d.IInvoiceID))
                .Include(d => d.Product)
                .GroupBy(d => d.IProductID)
                .Select(g => new ProductReportDTO
                {
                    ProductName = g.First().Product.SProductName,
                    QuantitySold = g.Sum(x => x.IQuantity)
                })
                .OrderByDescending(x => x.QuantitySold)
                .Take(5)
                .ToListAsync();

            var revenueByDate = await _context.Invoices
                .Where(i => invoiceIds.Contains(i.IInvoiceID))
                .GroupBy(i => i.DCreatedDate.Date)
                .Select(g => new RevenueByDateDTO
                {
                    Date = g.Key,
                    Revenue = g.Sum(i => i.FTotal)
                })
                .OrderBy(x => x.Date)
                .ToListAsync();

            return new ReportDTO
            {
                TotalInvoices = totalInvoices,
                TotalRevenue = totalRevenue,
                TopProducts = topProducts,
                RevenueByDate = revenueByDate
            };
        }

    }

}