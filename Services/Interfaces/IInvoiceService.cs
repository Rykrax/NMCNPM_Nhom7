using NMCNPM_Nhom7.DTOs;

namespace NMCNPM_Nhom7.Services
{
    public interface IInvoiceService
    {
        Task<bool> CreateInvoiceAsync(InvoiceDTO dto);
    }
}