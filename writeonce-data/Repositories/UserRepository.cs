using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreApp.Repositories
{

    public interface IUserRepository : IRepositoryBase<User>
    {

    }
    public class UserRepository : TRepository<User>, IUserRepository
    {
       public UserRepository(AppDbContext context) : base(context){  }

    }
}
