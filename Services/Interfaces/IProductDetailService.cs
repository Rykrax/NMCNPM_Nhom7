using NMCNPM_Nhom7.DTOs;

namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<List<ProductDetailDTO>> SearchByProductNameAsync(string keyword);
    }
}