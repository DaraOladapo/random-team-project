using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TeamAssignment.Data;
using TeamAssignment.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TeamAssignment.Respositories
{
   public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }
        public Repository(ApplicationDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public T Create(T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Update(T entity)
        {
            return RepositoryContext.Set<T>().Update(entity).Entity;
        }
    }
}