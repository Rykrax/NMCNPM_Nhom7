using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NMCNPM_Nhom7.DTOs
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string SProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn loại sản phẩm")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn loại sản phẩm hợp lệ")]
        public int ICategoryID { get; set; }

        [Required(ErrorMessage = "Giá nhập sản phẩm không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá nhập phải lớn hơn 0")]
        public decimal FImportPrice { get; set; }

        [Required(ErrorMessage = "Số lượng sản phẩm không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng sản phẩm phải lớn hơn 0")]
        public int IQuantity { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn đơn vị tính")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn đơn vị tính hợp lệ")]
        public int IUnitID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhà cung cấp")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn nhà cung cấp hợp lệ")]
        public int ISupplierID { get; set; }

        public List<SelectListItem> Categories { get; set; } = new();
        public List<SelectListItem> Units { get; set; } = new();
        public List<SelectListItem> Suppliers { get; set; } = new();
    }
}
