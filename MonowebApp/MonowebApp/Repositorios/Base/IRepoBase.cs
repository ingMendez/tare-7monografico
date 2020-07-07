using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MonowebApp.Repositorios.Base
{
   public interface IRepoBase<TEntity> where TEntity: class
    {
        IQueryable<TEntity> BuscarTodo();
        Task<TEntity> BuscarPorId(int? id);
        IQueryable<TEntity> BuscarPorCondicion(Expression<Func<TEntity, bool>> expression);
        Task Crear(TEntity entity);
        Task Modificar(TEntity entity);
        Task Eliminar(TEntity entity);
    }
}
