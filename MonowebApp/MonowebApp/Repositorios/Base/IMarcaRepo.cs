using MonowebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonowebApp.Repositorios.Base
{
   public interface IMarcaRepo : IRepoBase<Marca>
    {
        Task<List<Generico>> GetGenericList();
    }
}
