using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonowebApp.Models
{
    public class Modelo
    {
        [Key]
        public int IdModelo { get; set; }

        [Required]
        public int IdMarca { get; set; }
        public Marca Marca { get; set; } //Propiedad de navegación, indica que un modelo tiene una marca. tiwnw una relacion con modelo marca eso lo indica la propiedad  "Marca marca".

        [StringLength(50)]
        public string Nombre { get; set; }
        public int Año { get; set; }

      //  [Column("Version", TypeName = "varchar(20)")]
        public string Version { get; set; }
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }
        public bool Inactivo { get; set; }
    }
}
