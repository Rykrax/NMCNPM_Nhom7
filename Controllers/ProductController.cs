using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Data;
using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMCNPM_Nhom7.Services.Interfaces;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductService _productService;

    public ProductController(AppDbContext context, IProductService productService)
    {
        _context = context;
        _productService = productService;
    }

    [HttpGet("products")]
    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewModel = new CreateProductDTO
        {
            SProductName = string.Empty,
            ICategoryID = 0,
            FPrice = 0,
            IQuantity = 0,
            IUnitID = 0,
            ISupplierID = 0,
            Categories = await _context.ProductCategories
                .Select(c => new SelectListItem
                {
                    Value = c.ICategoryID.ToString(),
                    Text = c.SCategoryName
                }).ToListAsync(),
            Units = await _context.Units
                .Select(u => new SelectListItem
                {
                    Value = u.IUnitID.ToString(),
                    Text = u.SUnitName
                }).ToListAsync(),
            Suppliers = await _context.Suppliers
                .Select(s => new SelectListItem
                {
                    Value = s.ISupplierID.ToString(),
                    Text = s.SCompanyName
                }).ToListAsync()
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDTO model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var product = new ProductModel
        {
            SProductName = model.SProductName,
            ICategoryID = model.ICategoryID,
            FPrice = model.FPrice,
            IQuantity = model.IQuantity,
            IUnitID = model.IUnitID,
            ISupplierID = model.ISupplierID
        };

        await _productService.CreateProductAsync(product);

        return Json(new { success = true });
    }
}
