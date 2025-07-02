using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.Repositoties;
using NMCNPM_Nhom7.Services.Interfaces;

namespace NMCNPM_Nhom7.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public Task<List<EmployeeModel>> GetAllAsync()
        {
            return _userRepo.GetAllAsync();
        }

        public Task<EmployeeModel?> GetByIdAsync(int id)
        {
            return _userRepo.GetByIdAsync(id);
        }

        public Task<EmployeeModel> CreateAsync(EmployeeModel employee)
        {
            return _userRepo.CreateAsync(employee);
        }

        public Task<bool> UpdateAsync(int id, EmployeeModel employee)
        {
            return _userRepo.UpdateAsync(id, employee);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _userRepo.DeleteAsync(id);
        }
    }
}