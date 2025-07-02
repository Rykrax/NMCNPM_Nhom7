using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.Repositoties;
using NMCNPM_Nhom7.Services.Interfaces;
using NMCNPM_Nhom7.Helpers;

namespace NMCNPM_Nhom7.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<EmployeeModel?> RegisterAsync(RegisterDTO model)
        {
            if (!string.IsNullOrEmpty(model.Phone))
            {
                var existing = await _userRepo.GetByPhoneAsync(model.Phone);
                if (existing != null)
                    return null;
            }

            var employee = new EmployeeModel
            {
                SFullName = model.FullName,
                BGender = model.Gender,
                DBirthDate = model.BirthDate,
                SPhone = model.Phone,
                SEmail = model.Email,
                SCCCD = model.CCCD,
                SAddress = model.Address,
                SPasswordHash = PasswordHasher.Hash(model.Password),
                IRoleID = 2, // Mặc định: User
                SStatus = "active",
            };

            var created = await _userRepo.CreateAsync(employee);

            return created;
        }


        public async Task<EmployeeModel?> LoginAsync(LoginDTO model)
        {
            var user = await _userRepo.GetByPhoneAsync(model.PhoneNumber);
            if (user == null) return null;

            if (!PasswordHasher.Verify(model.Password, user.SPasswordHash))
                return null;
            // if (model.Password != user.SPasswordHash) return null;
            return user;
        }
    }
}
