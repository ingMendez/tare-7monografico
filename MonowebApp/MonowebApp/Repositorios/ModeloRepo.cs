using MonowebApp.Models;
using MonowebApp.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MonowebApp.Repositorios
{
  
        public class ModeloRepo : RepoBase<Modelo>, IModeloRepo
        {
            private readonly AppDbContext _context;
            public ModeloRepo(AppDbContext context) : base(context)
            {
                _context = context;
            }

        }
    
}
