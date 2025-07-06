using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NMCNPM_Nhom7.DTOs
{
    public class EditProductDTO : CreateProductDTO
    {
        public int IProductDetailID { get; set; }
    }
}
