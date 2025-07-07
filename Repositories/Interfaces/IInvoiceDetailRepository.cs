using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Repositories.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        Task AddInvoiceDetailsAsync(List<InvoiceDetailModel> details);
    }
}
