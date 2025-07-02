
using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IUserService
    {
        Task<EmployeeModel?> LoginAsync(LoginDTO model);
    }
}