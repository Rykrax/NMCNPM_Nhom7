using NMCNPM_Nhom7.Models;
using NMCNPM_Nhom7.Repositories;
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
            if (!string.IsNullOrEmpty(model.PhoneNumber))
            {
                var existingPhone = await _userRepo.GetByPhoneAsync(model.PhoneNumber);
                if (existingPhone != null)
                    throw new ArgumentException("Số điện thoại đã được sử dụng.");
            }

            if (!string.IsNullOrEmpty(model.CCCD))
            {
                var existingCccd = await _userRepo.GetByCCCDAsync(model.CCCD);
                if (existingCccd != null)
                    throw new ArgumentException("Căn cước công dân đã được sử dụng.");
            }

            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                var existingEmail = await _userRepo.GetByEmailAsync(model.Email);
                if (existingEmail != null)
                    throw new ArgumentException("Email đã được sử dụng.");
            }

            if (model.BirthDate > DateTime.Today)
                throw new ArgumentException("Ngày sinh không được lớn hơn ngày hiện tại.");

            var employee = new EmployeeModel
            {
                SFullName = model.FullName,
                BGender = model.Gender,
                DBirthDate = model.BirthDate,
                SPhone = model.PhoneNumber,
                SEmail = model.Email,
                SCCCD = model.CCCD,
                SAddress = model.Address,
                SPasswordHash = PasswordHasher.Hash(model.Password),
                IRoleID = 2,
                SStatus = "active"
            };

            return await _userRepo.CreateAsync(employee);
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
