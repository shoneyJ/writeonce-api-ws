using EFcoreApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreApp
{

    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
       
        Task<int> Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
