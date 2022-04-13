using ApplicatonProcess.December2020.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicatonProcess.December2020.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IServiceScope _scope;
        private readonly DatabaseContext _DatabaseContext;

        public EmployeeRepository(IServiceProvider service)
        {
            _scope = service.CreateScope();
            _DatabaseContext = _scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        }

        public Employee Get(int employeeId)
        {
            var result = _DatabaseContext.Employees
                                .Where(x => x.Id == employeeId)
                                .FirstOrDefault();

            return result;
        }

        public async Task<bool> Create(Employee employee)
        {
            var success = false;

            _DatabaseContext.Employees.Add(employee);

            var numberOfItemsCreated = await _DatabaseContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public async Task<bool> Update(Employee employee)
        {
            var success = false;

            var existingBlogPost = Get(employee.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Name = employee.Name;
                existingBlogPost.FamilyName = employee.FamilyName;
                existingBlogPost.Address = employee.Address;
                existingBlogPost.CountryOfOrigin = employee.CountryOfOrigin;
                existingBlogPost.EmailAddress = employee.EmailAddress;
                existingBlogPost.Age = employee.Age;
                existingBlogPost.Hired = employee.Hired;

                _DatabaseContext.Employees.Attach(existingBlogPost);

                var numberOfItemsUpdated = await _DatabaseContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }

        public async Task<bool> Delete(int employeeId)
        {
            var success = false;

            var existingBlogPost = Get(employeeId);

            if (existingBlogPost != null)
            {
                _DatabaseContext.Employees.Remove(existingBlogPost);

                var numberOfItemsDeleted = await _DatabaseContext.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }
    }
}
