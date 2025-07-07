using NMCNPM_Nhom7.DTOs;
using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.Repositories.Interfaces;

namespace NMCNPM_Nhom7.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repo;
        private readonly IInvoiceDetailRepository _repoDetail;

        public InvoiceService(IInvoiceRepository repo, IInvoiceDetailRepository repoDetail)
        {
            _repo = repo;
            _repoDetail = repoDetail;
        }

        public async Task<bool> CreateInvoiceAsync(InvoiceDTO dto)
        {
            int? userId = dto.EmployeeID;

            if (userId == null)
                return false;

            var invoice = new InvoiceModel
            {
                IEmployeeID = userId.Value,
                ICustomerID = dto.CustomerID,
                DCreatedDate = DateTime.Now,
                FTotal = dto.Total,
                FVAT = dto.VAT
            };

            var createdInvoice = await _repo.CreateInvoiceAsync(invoice);
            var invoiceID = createdInvoice.IInvoiceID;

            var details = dto.InvoiceDetails.Select(d => new InvoiceDetailModel
            {
                IInvoiceID = invoiceID,
                IProductID = d.ProductID,
                IQuantity = d.Quantity,
                FUnitPrice = d.UnitPrice
            }).ToList();

            await _repoDetail.AddInvoiceDetailsAsync(details);

            return true;
        }
    }
}
