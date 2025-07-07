public class ReportDTO
{
    public int TotalInvoices { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<ProductReportDTO> TopProducts { get; set; }
    public List<RevenueByDateDTO> RevenueByDate { get; set; }
}

public class ProductReportDTO
{
    public string ProductName { get; set; }
    public int QuantitySold { get; set; }
}

public class RevenueByDateDTO
{
    public DateTime Date { get; set; }
    public decimal Revenue { get; set; }
}
