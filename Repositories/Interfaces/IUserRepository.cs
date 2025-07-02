using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Repositoties
{
    public interface IUserRepository
    {
        Task<List<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel?> GetByIdAsync(int id);
        Task<EmployeeModel?> GetByPhoneAsync(string phoneNumber);
        Task<EmployeeModel?> GetByCCCDAsync(string cccd);
        Task<EmployeeModel?> GetByEmailAsync(string email);
        Task<EmployeeModel> CreateAsync(EmployeeModel employee);
        Task<bool> UpdateAsync(int id, EmployeeModel employee);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}