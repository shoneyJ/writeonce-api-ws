using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreApp.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
    }
    public class TRepository<T> : IRepositoryBase<T> where T : class
    {
        internal AppDbContext context;
        internal DbSet<T> dbSet;

        public TRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

       
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await this.dbSet.FindAsync(id);
        }
    }
}
