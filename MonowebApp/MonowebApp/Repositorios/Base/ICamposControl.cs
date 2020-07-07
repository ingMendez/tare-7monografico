using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonowebApp.Repositorios.Base
{
   public  interface ICamposControl
    {
        DateTime Creado { get; set; }
        //int CreadoPorId { set; get; }
        DateTime Modificado { get; set; }
        //int ModificadoPorId { get; set; }
        bool Inactivo { get; set; }
    }
}
