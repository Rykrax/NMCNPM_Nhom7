using NMCNPM_Nhom7.DTOs;
using NMCNPM_Nhom7.Repositories.Interfaces;
using NMCNPM_Nhom7.Services.Interfaces;

namespace NMCNPM_Nhom7.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _repository;

        public ProductDetailService(IProductDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDetailDTO>> SearchByProductNameAsync(string keyword)
        {
            return await _repository.SearchByProductNameAsync(keyword);
        }
    }
}