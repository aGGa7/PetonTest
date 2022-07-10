using Microsoft.EntityFrameworkCore;
using Service.Context;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.DAL
{
    public class GenericRepository <TEntity> : IGenericRepository<TEntity> where TEntity: class
    {
        internal DataContext _context;
        internal DbSet<TEntity> _dbSet;
        public GenericRepository(DataContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetEntities (Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            foreach(var propery in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(propery);
            }
            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToArray();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
