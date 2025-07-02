using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Services.Interfaces
{
    public interface IAuthService
    {
        Task<EmployeeModel?> RegisterAsync(RegisterDTO model);
        Task<EmployeeModel?> LoginAsync(LoginDTO model);
    }
}