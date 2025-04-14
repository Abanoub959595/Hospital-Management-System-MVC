using Hospital.Models;
using Hospital.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Implementations
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        private readonly ApplicationDbContext context;
        private Hashtable repositories;
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

        public void save()
        {
            context.SaveChanges();
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            if (repositories is null)
                repositories = new Hashtable();

            var entityKey = typeof(T).Name; 

            if (!repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<>); 

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);

                repositories.Add(entityKey, repositoryInstance);
            }
            return (GenericRepository<T>)repositories[entityKey];
        }
    }
}
