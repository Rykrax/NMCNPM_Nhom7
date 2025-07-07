using NMCNPM_Nhom7.DTOs;

namespace NMCNPM_Nhom7.Repositories.Interfaces
{
    public interface IProductDetailRepository
    {
        Task<List<ProductDetailDTO>> SearchByProductNameAsync(string keyword);
    }
}