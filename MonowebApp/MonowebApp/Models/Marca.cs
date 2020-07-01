using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MonowebApp.Models;


namespace MonowebApp.Models
{
    public class Marca
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
