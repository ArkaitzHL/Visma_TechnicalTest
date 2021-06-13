using Visma_TechnicalTest.Core;
using Visma_TechnicalTest.Core.Repositories;
using Visma_TechnicalTest.Data.Repositories;

namespace Visma_TechnicalTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables
        private readonly TechnicalTestDbContext _context;
        private EmployeeRepository _employeeRepository;
        public IEmployeeRepository Employees => _employeeRepository ??= new EmployeeRepository(_context);
        #endregion

        #region Contructor
        public UnitOfWork(TechnicalTestDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}