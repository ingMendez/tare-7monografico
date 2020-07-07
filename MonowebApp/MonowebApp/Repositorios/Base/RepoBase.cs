using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonowebApp.Models;

namespace MonowebApp.Repositorios.Base
{
    public abstract class RepoBase<TEntity> : IRepoBase<TEntity> where TEntity : class, ICamposControl
    {

        private readonly AppDbContext _repoContext;
        public RepoBase(AppDbContext repoContexto) 
        {

            _repoContext = repoContexto;
        }
        public IQueryable<TEntity> BuscarPorCondicion(Expression<Func<TEntity, bool>> expression)
        {
            return _repoContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> BuscarPorId(int? id)
        {
            return await  _repoContext.Set<TEntity>().FindAsync(id);
        }
        
        /// <summary>
        /// Buscar todo
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> BuscarTodo()
        {
            return _repoContext.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Crear"></param>
        /// <returns></returns>
        public async Task Crear(TEntity entity)
        {
            try
            {
                entity.Creado = DateTime.Now;
                //entity.creadoporid = 0;
                entity.Modificado = DateTime.Now;
                //entity.ModificadoPorId = _user.GetUserID().ToInt();
                entity.Inactivo = false;
                await  _repoContext.Set<TEntity>().AddAsync(entity);
                await  _repoContext.SaveChangesAsync();
            }
            catch(Exception Ex)
            {
                throw Ex;
                //_logger.LogDebug(ex, "No se puedo crear registro.");
            }
        }

        /// <summary>
        /// eliminar 
        /// </summary>
        /// <param name="Eliminar"></param>
        /// <returns></returns>
        public async Task Eliminar(TEntity entity)
        {
            try
            {
                //elimina definitivamente el registro
                //_repoContext.Set<TEntity>().Remove(entity);
                //await _repoContext.SaveChangesAsync();

                _repoContext.Set<TEntity>().Update(entity);
                entity.Modificado = DateTime.Now;
                // entity.ModificadoPorId = _user.GetUserID().ToInt();
                _repoContext.Entry(entity).Property(c => c.Creado).IsModified = false;
                //_repoContext.Entry(entity).Property(c => c.CreadoPorId).IsModified = false;
                _repoContext.Entry(entity).Property(c => c.Inactivo).IsModified = false;
                entity.Inactivo = true;
                await _repoContext.SaveChangesAsync();

            }
            catch (Exception Ex)
            {
                throw Ex;
                //_logger.LogDebug(ex, "No se puedo crear registro.");
            }
        }
        /// <summary>
        /// Actualiza cualquier objeto 
        /// </summary>
        /// <param name="Modificar">Un objeto de clase.</param>
        /// <returns></returns>

        public async Task Modificar(TEntity entity)
        {
            try
            {
                _repoContext.Set<TEntity>().Update(entity);
                entity.Modificado = DateTime.Now;
                // entity.ModificadoPorId = _user.GetUserID().ToInt();
                _repoContext.Entry(entity).Property(c => c.Creado).IsModified = false;
                //_repoContext.Entry(entity).Property(c => c.CreadoPorId).IsModified = false;
                _repoContext.Entry(entity).Property(c => c.Inactivo).IsModified = false;
                await _repoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
                //_logger.LogDebug(ex, "No se pudo actualizar el registro.");
            }
        }
    }
}
