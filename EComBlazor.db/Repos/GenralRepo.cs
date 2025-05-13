using EComBlazor.db.Base;
using EComBlazor.db.Contexts;
using EComBlazor.lib.Exceptions;
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

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
