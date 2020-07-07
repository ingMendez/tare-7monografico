using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonowebApp.Models;

namespace MonowebApp.Models
{
    public class OldDbContext //: DbContext //que no erede de contexto de .net core. 
    {

       /* public OldDbContext()
        {

        }
        public OldDbContext(DbContextOptions<OldDbContext>options)
            :base (options)
        {    }
        public DbSet<MonowebApp.Models.Marca> Marca { get; set; }
        public DbSet<MonowebApp.Models.Modelo> Modelo { get; set; }

        */
    }
}
