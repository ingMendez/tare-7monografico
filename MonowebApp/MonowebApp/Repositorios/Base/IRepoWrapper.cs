using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonowebApp.Repositorios.Base
{
    public interface IRepoWrapper
    {
        //Solo colocamos las propiedades tipo get.
        IModeloRepo Modelo { get; }
        IMarcaRepo Marca { get; }
    }
}
