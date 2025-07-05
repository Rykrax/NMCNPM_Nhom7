using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Services.Interfaces;

namespace NMCNPM_Nhom7.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    
    [HttpGet("/register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var user = await _authService.RegisterAsync(model);
            if (user == null)
                return StatusCode(500, new { message = "Lỗi khi tạo người dùng." });

            return Ok(new
            {
                status = 200,
                message = "Đăng ký thành công",
                data = new
                {
                    user.IEmployeeID,
                    user.SFullName,
                    user.SPhone
                }
            });
        }
        catch (ArgumentException ex)
        {
            return Conflict(new { status = 409, message = ex.Message });
        }
    }


    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        var user = await _authService.LoginAsync(dto);
        if (user == null)
            return Unauthorized(new
            {
                status = 401,
                message = "Số điện thoại hoặc mật khẩu không chính xác"
            });

        HttpContext.Session.SetString("UserName", user.SFullName); // Lưu chuỗi
        HttpContext.Session.SetInt32("UserID", user.IEmployeeID);      // Lưu số nguyên

        return Ok(new
        {
            status = 200,
            message = "Đăng nhập thành công",
            // data = user
        });
    }
}