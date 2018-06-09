using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kaizen.Server.Repository.Interface
{
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
    
    public interface IRepository
    {
        
    }
}