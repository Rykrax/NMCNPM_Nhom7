using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.DTOs;
using NMCNPM_Nhom7.Repositories.Interfaces;
using NMCNPM_Nhom7.Services;
using NMCNPM_Nhom7.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : Controller
{
    private readonly AppDbContext _context;
    private readonly IInvoiceService _invoiceService;
    private readonly IInvoiceDetailService _invoiceDetailService;

    public InvoiceController(AppDbContext context, IInvoiceService invoiceService, IInvoiceDetailService invoiceDetailService)
    {
        _context = context;
        _invoiceService = invoiceService;
        _invoiceDetailService = invoiceDetailService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InvoiceDTO dto)
    {
        try
        {
            if (dto.EmployeeID == null || dto.EmployeeID <= 0)
                return BadRequest("Thiếu mã nhân viên.");

            var success = await _invoiceService.CreateInvoiceAsync(dto);

            if (success)
                return Ok(new { message = "Tạo hóa đơn thành công." });
            else
                return BadRequest("Không thể tạo hóa đơn.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi server: {ex.Message}");
        }
    }

}