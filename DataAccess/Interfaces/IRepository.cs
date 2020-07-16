using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task CreateAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetByAsync(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}