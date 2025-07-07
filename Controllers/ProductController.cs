using Microsoft.AspNetCore.Mvc;
using NMCNPM_Nhom7.Data;
using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using NMCNPM_Nhom7.Services.Interfaces;
using NMCNPM_Nhom7.Models;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductService _productService;
    private readonly IProductDetailService _productDetailService;

    public ProductController(AppDbContext context, IProductService productService, IProductDetailService productDetailService)
    {
        _context = context;
        _productService = productService;
        _productDetailService = productDetailService;
    }

    [HttpGet("/products")]
    public async Task<IActionResult> Index()
    {
        var productList = await _context.ProductDetails
            .Include(d => d.Product)
            .Select(d => new ProductDisplayModel
            {
                ProductID = d.IProductID,
                ProductDetailID = d.IProductDetailID,
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
        var productDetail = await _productService.GetProductDetailsAsync(id);
        if (productDetail == null)
        {
            return NotFound();
        }
        var product = await _productService.GetProductByIdAsync(productDetail.IProductID);
        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new EditProductDTO
        {
            IProductDetailID = productDetail.IProductDetailID,
            SProductName = product.SProductName ?? string.Empty,
            ICategoryID = product.ICategoryID ?? 0,
            IUnitID = productDetail.IUnitID,
            ISupplierID = productDetail.ISupplierID,
            FImportPrice = productDetail.FImportPrice ?? 0,
            IQuantity = productDetail.IQuantity,
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
    public async Task<IActionResult> Edit([FromBody] EditProductDTO model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, message = "Dữ liệu không hợp lệ." });
        }

        var result = await _productService.UpdateProductAsync(model.IProductDetailID, model);
        if (!result)
        {
            return Json(new { success = false, message = "Cập nhật sản phẩm không thành công." });
        }

        return Json(new { success = true, message = "Sản phẩm đã được cập nhật thành công!" });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productService.DeleteProductAsync(id);
        if (!result)
        {
            return Json(new { success = false, message = "Xóa sản phẩm không thành công." });
        }

        return Json(new { success = true, message = "Sản phẩm đã được xóa thành công!" });
    }

    [HttpGet("/search-products")]
    public async Task<JsonResult> Search(string keyword)
    {
        var result = await _productDetailService.SearchByProductNameAsync(keyword);
        return Json(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetDetailJson(int id)
    {
        var detail = await _productService.GetProductDetailsAsync(id);
        if (detail == null)
            return NotFound();

        var product = await _productService.GetProductByIdAsync(detail.IProductID);
        if (product == null)
            return NotFound();

        var category = await _context.ProductCategories.FindAsync(product.ICategoryID);
        var unit = await _context.Units.FindAsync(detail.IUnitID);
        var supplier = await _context.Suppliers.FindAsync(detail.ISupplierID);

        return Json(new
        {
            productName = product.SProductName,
            sellPrice = detail.FSellPrice,
            quantity = detail.IQuantity,
            categoryName = category?.SCategoryName,
            unitName = unit?.SUnitName,
            supplierName = supplier?.SCompanyName
        });
    }
}
