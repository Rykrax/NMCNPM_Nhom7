using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMCNPM_Nhom7.Data;
using NMCNPM_Nhom7.Models;

namespace NMCNPM_Nhom7.Repositoties
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            return await _context.Employees
                                .Include(e => e.IRole)
                                .ToListAsync();
        }

        public async Task<EmployeeModel?> GetByIdAsync(int id)
        {
            return await _context.Employees
                                .Include(e => e.IRole)
                                .FirstOrDefaultAsync(e => e.IEmployeeID == id);
        }

        public async Task<EmployeeModel?> GetByPhoneAsync(string phoneNumber)
        {
            return await _context.Employees
                         .FirstOrDefaultAsync(e => e.SPhone == phoneNumber);
        }

        public async Task<EmployeeModel?> GetByCCCDAsync(string cccd)
        {
            return await _context.Employees
                         .FirstOrDefaultAsync(e => e.SCCCD == cccd);
        }

        public async Task<EmployeeModel?> GetByEmailAsync(string email)
        {
            return await _context.Employees
                         .FirstOrDefaultAsync(e => e.SEmail == email);
        }

        public async Task<EmployeeModel> CreateAsync(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateAsync(int id, EmployeeModel employee)
        {
            if (id != employee.IEmployeeID)
                return false;

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return await ExistsAsync(id);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Employees.AnyAsync(e => e.IEmployeeID == id);
        }
    }
}