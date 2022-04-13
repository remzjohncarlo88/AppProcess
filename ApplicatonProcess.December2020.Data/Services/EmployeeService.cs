using ApplicatonProcess.December2020.Data.Repositories;
using ApplicatonProcess.December2020.Domain.Models;
using System.Threading.Tasks;

namespace .ApplicatonProcess.December2020.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Employee Get(int employeeId)
        {
            var result = _repository.Get(employeeId);

            return result;
        }

        public async Task<Employee> Create(Employee employee)
        {
            var success = await _repository.Create(employee);

            if (success)
                return employee;
            else
                return null;
        }

        public async Task<Employee> Update(Employee employee)
        {
            var success = await _repository.Update(employee);

            if (success)
                return employee;
            else
                return null;
        }

        public async Task<bool> Delete(int EmployeeId)
        {
            var success = await _repository.Delete(EmployeeId);

            return success;
        }
    }
}
