using ITS_Task.Business.DTOs;
using ITS_Task.Business.DTOs;
using ITS_Task.Business.Interfaces;
using ITS_Task.DataAccess.Interfaces;
using ITS_Task.Models;
using Microsoft.EntityFrameworkCore;
namespace ITS_Task.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> AddAsync(CreateEmployeeDto employeeDto)
        {

            var existingEmployee = await _employeeRepository.GetByEmailAsync(employeeDto.Email);

            if (existingEmployee != null)
            {
                throw new Exception("Email already exists");
            }


            if (employeeDto.HireDate > DateTime.Now)
            {
                throw new Exception("Hire date cannot be in the future");
            }

            var employee = new Employee
            {
                FullName = employeeDto.FullName,
                Email = employeeDto.Email,
                Department = employeeDto.Department,
                JobTitle = employeeDto.JobTitle,
                HireDate = employeeDto.HireDate
            };

            var result =  await _employeeRepository.AddAsync(employee);

            return new EmployeeDto
            {
                EmployeeId = result.Id,
                FullName = result.FullName,
                Email = result.Email,
                Department = result.Department,
                JobTitle = result.JobTitle,
                HireDate = result.HireDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return false;

            await _employeeRepository.DeleteAsync(employee);

            return true;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(e => new EmployeeDto
            {
                EmployeeId = e.Id,
                FullName = e.FullName,
                Email = e.Email,
                Department = e.Department,
                JobTitle = e.JobTitle,
                HireDate = e.HireDate
            }).ToList();
        }

        
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {

            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return null;


            return new EmployeeDto
            {
                EmployeeId = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                Department = employee.Department,
                JobTitle = employee.JobTitle,
                HireDate = employee.HireDate
            };

        }

        public async Task<List<EmployeeDto>> SearchAsync(string search)
        {
          


            var employees =
                await _employeeRepository.SearchAsync(search);


            return employees.Select(e => new EmployeeDto
            {
                EmployeeId = e.Id,
                FullName = e.FullName,
                Email = e.Email,
                Department = e.Department,
                JobTitle = e.JobTitle,
                HireDate = e.HireDate

            }).ToList();
        }


        public async Task<EmployeeDto?> UpdateAsync(int id,UpdateEmployeeDto employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return null;


            employee.FullName = employeeDto.FullName;
            employee.Email = employeeDto.Email;
            employee.Department = employeeDto.Department;
            employee.JobTitle = employeeDto.JobTitle;
            employee.HireDate = employeeDto.HireDate;


            await _employeeRepository.UpdateAsync(employee);


            return new EmployeeDto
            {
                EmployeeId = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                Department = employee.Department,
                JobTitle = employee.JobTitle,
                HireDate = employee.HireDate
            };
        }

    }
}