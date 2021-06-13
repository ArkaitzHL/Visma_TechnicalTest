using System;
using Visma_TechnicalTest.Core.Repositories;

namespace Visma_TechnicalTest.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        int SaveChanges();
    }
}
