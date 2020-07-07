using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MonowebApp.Models;
using MonowebApp.Repositorios.Base;

namespace MonowebApp.Models
{
    [Table("tblMarcas")]
    public class Marca : ICamposControl
    {
        [Key]
        public int IdMarca { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }

        public bool Inactivo { get; set; }

        public ICollection<Modelo> Modelos; //Propiedad de Navegacion, indica que una Marca puede tener muchos modelos.
    }
}
