using System.Collections.Generic;
using Visma_TechnicalTest.Core.Models;

namespace Visma_TechnicalTest.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAll();
        void Add(Employee employee);
    }
}
