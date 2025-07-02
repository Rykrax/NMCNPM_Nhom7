using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public UserController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
