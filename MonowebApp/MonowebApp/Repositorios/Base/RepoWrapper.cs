using MonowebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonowebApp.Repositorios;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MonowebApp.Repositorios.Base
{
    public class RepoWrapper : IRepoWrapper
    {
        private readonly AppDbContext _repoContext;
        private IModeloRepo _modelo;
        private IMarcaRepo _marca;

        public RepoWrapper(AppDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IMarcaRepo Marca
        {
            get
            {
                if (_marca ==null)
                {
                    _marca = new MarcaRepo(_repoContext);
                }
                return _marca;
            }
        }

        public IModeloRepo Modelo
        {
            get
            { 
             if(_modelo==null)
                {
                    _modelo = new ModeloRepo(_repoContext);
                }
                return _modelo;
            }
        }
            

      
    }
}
