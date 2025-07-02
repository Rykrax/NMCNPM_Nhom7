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

    // [HttpPost("register")]
    // public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    // {
    //     var result = await _authService.RegisterAsync(dto);
    //     if (result == null)
    //         return BadRequest("Email đã tồn tại");

    //     return Ok(result);
    // }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); 

        var user = await _authService.RegisterAsync(model);

        if (user == null)
            return Conflict(new { message = "Số điện thoại đã được đăng ký." }); // 409 Conflict

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

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        var user = await _authService.LoginAsync(dto);
        if (user == null)
            return Unauthorized("Email hoặc mật khẩu không chính xác!");

        return Ok(new
        {
            status = 200,
            message = "Đăng nhập thành công",
            data = user
        });
    }
}