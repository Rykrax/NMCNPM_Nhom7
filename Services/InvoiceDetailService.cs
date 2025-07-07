using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.Repositories.Interfaces;
using NMCNPM_Nhom7.Services.Interfaces;

namespace NMCNPM_Nhom7.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepo;

        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepo)
        {
            _invoiceDetailRepo = invoiceDetailRepo;
        }

        public async Task AddInvoiceDetailsAsync(List<InvoiceDetailModel> details)
        {
            await _invoiceDetailRepo.AddInvoiceDetailsAsync(details);
        }
    }
}
