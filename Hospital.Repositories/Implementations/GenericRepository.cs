using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Implementations
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        internal DbSet<T> dbset;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        public void Add(T entity)
            => dbset.Add(entity);   

        public async Task AddAsync(T entity)
            => await dbset.AddAsync(entity);

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbset.Attach(entity);   
            dbset.Remove(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbset.Attach(entity);

            dbset.Remove(entity);
            return entity;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filters = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbset;
            if (filters is not null)
                query = query.Where(filters);

            foreach (var include in
                includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(include);

            if (orderBy is not null)
                return orderBy(query).ToList();
            else 
                return query.ToList();

        }

        public T GetById(object id)
            => dbset.Find(id);

        public async Task<T> GetByIdAsync(object id)
            => await dbset.FindAsync(id);

        public void Update(T entity)
            => dbset.Update(entity);

        public async Task<T> UpdateAsync(T entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
