using System.Collections.Generic;
using Visma_TechnicalTest.Core.Models;

namespace Visma_TechnicalTest.Core.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        void CreateEmployee(Employee employee);
    }
}
