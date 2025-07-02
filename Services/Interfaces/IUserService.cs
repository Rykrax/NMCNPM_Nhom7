
using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<EmployeeModel>> GetAllAsync();
        public Task<EmployeeModel?> GetByIdAsync(int id);
        public Task<EmployeeModel> CreateAsync(EmployeeModel employee);
        public Task<bool> UpdateAsync(int id, EmployeeModel employee);
        public Task<bool> DeleteAsync(int id);
        
    }
}