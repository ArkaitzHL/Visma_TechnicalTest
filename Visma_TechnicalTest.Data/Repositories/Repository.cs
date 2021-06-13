using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Visma_TechnicalTest.Core.Repositories;

namespace Visma_TechnicalTest.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        #region Contructor
        public Repository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Public Methods
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        #endregion
    }
}
