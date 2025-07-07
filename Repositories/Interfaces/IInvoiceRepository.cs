namespace NMCNPM_Nhom7.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<InvoiceModel> CreateInvoiceAsync(InvoiceModel invoice);
    }
}