namespace NMCNPM_Nhom7.DTOs
{
    public class InvoiceDTO
    {
        public int EmployeeID { get; set; }
        public int? CustomerID { get; set; }
        public decimal Total { get; set; }
        public decimal VAT { get; set; } = 0;
        public List<InvoiceDetailDTO> InvoiceDetails { get; set; } = new();
    }
}