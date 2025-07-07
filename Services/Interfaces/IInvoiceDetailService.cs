using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task AddInvoiceDetailsAsync(List<InvoiceDetailModel> details);
    }
}
