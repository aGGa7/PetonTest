using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(object id);
        void Add(TEntity entity);
        void Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}
