using System.Collections.Generic;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Core.Repositories;

namespace Visma_TechnicalTest.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private TechnicalTestDbContext TechnicalTestDbContext
        {
            get { return Context as TechnicalTestDbContext; }
        }

        #region Contructor
        public EmployeeRepository(TechnicalTestDbContext context)
            : base(context)
        { }
        #endregion

        #region Public Methods
        public IEnumerable<Employee> GetAll()
        {
            return TechnicalTestDbContext.Employees;
        }

        public void Add(Employee employee)
        {
            TechnicalTestDbContext.Employees.Add(employee);
        }
        #endregion
    }
}
