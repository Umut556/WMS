using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Infrastructure.DataAccess.Implementations.EF
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        public async Task DeleteAsync(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Remove(entity);
            await ctx.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var include in includeList)
                        // ctx.Products.Include("Category").Include... -->  // dbSet = ctx.Products = ctx.Set<TEntity>()
                        dbSet = dbSet.Include(include);
                }

                return await dbSet.SingleOrDefaultAsync(predicate);
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            // ctx.Products.Include("Category").Include("Employee")..Where(x=>x.Id >3).ToList();
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                // dbSet = ctx.Products

                if (includeList.Length > 0)
                {
                    foreach (var include in includeList)
                        // ctx.Products.Include("Category").Include... -->  // dbSet = ctx.Products = ctx.Set<TEntity>()
                        dbSet = dbSet.Include(include);
                }
                // dbSet = ctx.Products.Include("Category")..

                if (predicate == null)
                    return await dbSet.ToListAsync();

                return await dbSet.Where(predicate).ToListAsync();
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            using var ctx = new TContext();

            var entityEntry = ctx.Set<TEntity>().AddAsync(entity);

            await ctx.SaveChangesAsync();
            return entityEntry.Result.Entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Update(entity);
            await ctx.SaveChangesAsync();
        }
    }
}
