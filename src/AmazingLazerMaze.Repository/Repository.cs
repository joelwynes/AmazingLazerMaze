using JoelWynes.AmazingLazerMaze.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JoelWynes.AmazingLazerMaze.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
    }
}
