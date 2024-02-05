using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Interfaces
{
    public interface IBaseRepositories<T>
    {
        // Create
        Task AddAsync(T entity);
        // Read
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        // Update
        Task UpdateAsync(T entity);
        // Update 2
        Task<bool> Update2Async(T entity);
        // Delete
        Task DeleteAsync(Guid id);
        // Delete 2
        Task<bool> Delete2Async(Guid id);


    }
}
