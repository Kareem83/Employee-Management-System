using ITS_Task.DataAccess.Interfaces;
using ITS_Task.Models;
using ITS_Task.DataAccess;
using Microsoft.EntityFrameworkCore;
using ITS_Task.Business.DTOs;
namespace ITS_Task.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {


        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }


        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task<List<Employee>> SearchAsync(string search)
        {
            return await _context.Employees.Where(e => e.FullName.Contains(search) || e.Email.Contains(search)).ToListAsync();
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
