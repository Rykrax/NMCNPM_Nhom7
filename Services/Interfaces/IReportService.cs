namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportDTO> GetReportAsync(DateTime? fromDate, DateTime? toDate);
    }
}