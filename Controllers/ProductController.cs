using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Data;
using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMCNPM_Nhom7.Services.Interfaces;
using NMCNPM_Nhom7.Models;

public class ProductController : BaseController
{
    private readonly AppDbContext _context;
    private readonly IProductService _productService;

    public ProductController(AppDbContext context, IProductService productService)
    {
        _context = context;
        _productService = productService;
    }

    [HttpGet("/products")]
    public async Task<IActionResult> Index()
    {
        var productList = await _context.ProductDetails
            .Include(d => d.Product)
            .Select(d => new ProductDisplayModel
            {
                ProductID = d.IProductID,
                ProductName = d.Product!.SProductName,
                SellPrice = d.FSellPrice,
                Quantity = d.IQuantity
            })
            .ToListAsync();



        return View(productList);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewModel = new CreateProductDTO
        {
            SProductName = string.Empty,
            ICategoryID = 0,
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

        viewModel.Categories.Insert(0, new SelectListItem { Value = "", Text = "-- Chọn loại sản phẩm --" });
        viewModel.Units.Insert(0, new SelectListItem { Value = "", Text = "-- Chọn đơn vị tính --" });
        viewModel.Suppliers.Insert(0, new SelectListItem { Value = "", Text = "-- Chọn nhà cung cấp --" });

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDTO model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, message = "Dữ liệu không hợp lệ." });
        }

        var product = await _context.Products
            .Include(p => p.ProductDetails)
            .FirstOrDefaultAsync(p =>
                p.SProductName == model.SProductName &&
                p.ICategoryID == model.ICategoryID
            );

        if (product != null)
        {
            var existingDetail = product.ProductDetails.FirstOrDefault(d =>
                d.IUnitID == model.IUnitID &&
                d.ISupplierID == model.ISupplierID
            );

            if (existingDetail != null)
            {
                existingDetail.IQuantity += model.IQuantity;
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Sản phẩm đã tồn tại, số lượng đã được cập nhật." });
            }
        }
        else
        {
            product = new ProductModel
            {
                SProductName = model.SProductName,
                ICategoryID = model.ICategoryID
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        var productDetail = new ProductDetailModel
        {
            IProductID = product.IProductID,
            FImportPrice = model.FImportPrice,
            FSellPrice = model.FImportPrice, 
            IQuantity = model.IQuantity,
            IUnitID = model.IUnitID,
            ISupplierID = model.ISupplierID
        };

        _context.ProductDetails.Add(productDetail);
        await _context.SaveChangesAsync();

        return Json(new { success = true, message = "Sản phẩm đã được thêm thành công!" });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new CreateProductDTO
        {
            SProductName = product.SProductName ?? string.Empty,
            ICategoryID = product.ICategoryID ?? 0,
            FPrice = product.FPrice ?? 0,
            IQuantity = product.IQuantity,
            IUnitID = product.IUnitID ?? 0,
            ISupplierID = product.ISupplierID ?? 0,
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
}
