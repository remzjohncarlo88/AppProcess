using ApplicatonProcess.December2020.Domain.Models;
using System.Threading.Tasks;

namespace ApplicatonProcess.December2020.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Get(int employeeId);

        Task<bool> Create(Employee employee);

        Task<bool> Update(Employee employee);

        Task<bool> Delete(int employeeId);
    }
}
