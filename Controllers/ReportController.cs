using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Services.Interfaces;

namespace NMCNPM_Nhom7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
    {
        var report = await _reportService.GetReportAsync(fromDate, toDate);
        return Ok(report);
    }
}
