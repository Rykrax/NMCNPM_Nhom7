using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/home")]
    public IActionResult HomePage()
    {
        return View();
    }

    [HttpGet("/report")]
    public IActionResult Report()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
