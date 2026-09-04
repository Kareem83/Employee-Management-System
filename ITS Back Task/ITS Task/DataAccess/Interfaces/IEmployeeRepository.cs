using ITS_Task.Models;

namespace ITS_Task.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> AddAsync(Employee employee);

        Task<Employee?> GetByIdAsync(int id);

        Task<Employee> UpdateAsync(Employee employee);

        Task DeleteAsync(Employee employee);

        Task<List<Employee>> SearchAsync(string searchTerm);


        Task<Employee?> GetByEmailAsync(string email);

    }

}
