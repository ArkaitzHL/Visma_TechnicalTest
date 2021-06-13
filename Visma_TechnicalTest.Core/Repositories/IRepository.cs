using System.Collections.Generic;

namespace Visma_TechnicalTest.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
    }
}
