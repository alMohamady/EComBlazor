using EComBlazor.db.Base;
using EComBlazor.db.Contexts;
using EComBlazor.lib.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Repos
{
    public class GenralRepo<T>(AppDbContext appDb) : IGenralRepo<T> where T : class
    {
        public async Task<int> AddAsync(T entity)
        {
            appDb.Set<T>().Add(entity);
            return await appDb.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await appDb.Set<T>().FindAsync(id);
            if (entity == null)
                throw new ItemNotFoundEx($"Item '{id}' not found");
            appDb.Set<T>().Remove(entity);
            return await appDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await appDb.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            var item = await appDb.Set<T>().FindAsync(id);
            if (item == null)
                throw new ItemNotFoundEx($"Item '{id}' not found");
            return item!;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            appDb.Set<T>().Update(entity);
            return await appDb.SaveChangesAsync();
        }
    }
}
