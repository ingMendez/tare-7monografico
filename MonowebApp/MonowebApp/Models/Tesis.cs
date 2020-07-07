using Microsoft.AspNetCore.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MonowebApp.Models
{
    public class Tesis
    {
        [Key]
        public int IdTesis { get; set; }
        public string Imagen { get; set; }
        public string AutorPersonal { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string VolumenDimension { get; set; }
        public string NotasGenerales { get; set; }
        public string NotaTesis { get; set; }
        public string NotaBibliografia { get; set; }
        public string NotaDeContenido { get; set; }
        public string NotaDeResumen { get; set; }
        public string NotaSobreOtrosFormulario { get; set; }
        public string EncabezamientoBajoTemasGenerales { get; set; }
        public string EncabezamientoBajoNombreHeograficos { get; set; }
        public string AsientoSecundarioAutorPersonal { get; set; }
        public string LigaRecursosElectronicos { get; set; }

    }
}
