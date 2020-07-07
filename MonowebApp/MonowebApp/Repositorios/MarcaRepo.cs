using Microsoft.EntityFrameworkCore;
using MonowebApp.Models;
using MonowebApp.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonowebApp.Repositorios
{
    public class MarcaRepo : RepoBase<Marca>, IMarcaRepo
    {
            private readonly AppDbContext _context;
        public MarcaRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<Generico>> GetGenericList()
        {
                var lista = await (from datos in _context.Marca.AsNoTracking().AsQueryable()
                                   .Where(x => x.Inactivo == false)
                                   select new Generico
                                   {
                                       Id = datos.IdMarca.ToString(),
                                       Name = datos.Nombre
                                   }).ToListAsync();
                if (lista == null || lista.Count <= 0)
                {
                    lista.Add(new Generico()
                    {
                        Id = string.Empty,
                        Name = "No Exiten datos."
                    });
                }
                return lista;
            

        }
    }
}

