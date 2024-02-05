using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;

namespace TopTeacher.Persistance.Repositories
{
    public class BaseRepositories<T> : IBaseRepositories<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public BaseRepositories(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await context.Set<T>().FindAsync(id);

            if (item != null)
            {
                context.Set<T>().Remove(item);
                await context.SaveChangesAsync();
            }

        }
        public async Task<bool> Delete2Async(Guid id)
        {
            var item = await context.Set<T>().FindAsync(id);

            if (item != null)
            {
                var check = context.Set<T>().Remove(item);
                await context.SaveChangesAsync();

                if (check != null)
                    return true;
            }

            return false;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var allRows = await context.Set<T>().ToListAsync();
            return allRows;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var response = await context.Set<T>().FindAsync(id);

            return response;
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

        }
        public async Task<bool> Update2Async(T entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true; // Return true if the update is successful
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application
                // You might also return false or throw a custom exception depending on your needs
                return false; // Return false if the update fails
            }
        }
    }
}
