using ApplicatonProcess.December2020.Domain.Models;
using System.Threading.Tasks;

namespace ApplicatonProcess.December2020.Data.Services
{
    public interface IEmployeeService
    {
        Employee Get(int employeeId);

        Task<Employee> Create(Employee employee);

        Task<Employee> Update(Employee employee);

        Task<bool> Delete(int employeeId);
    }
}
