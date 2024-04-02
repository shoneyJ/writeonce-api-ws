using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreApp
{
    public class AppDbContext : DbContext
    {
        //private readonly string _connectionString;
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }


        public virtual DbSet<User> Users { get; set; }

     //   protected override void OnConfiguring(DbContextOptionsBuilder options)
     //=> options.UseNpgsql(_connectionString);

    }
}
