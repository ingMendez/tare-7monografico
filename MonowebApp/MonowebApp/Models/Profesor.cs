using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonowebApp.Models
{
    public class Profesor
    {
        [Key]

        public int IdProfesor { get; set; }
        public string Codigo { get; set; }
        public string Cedula { get; set; }
       public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil  { get; set; }
        public string Ocupación { get; set; }
        public string TipoSangre { get; set; }
        public string Nacionalidad { get; set; }
        public string Religión { get; set; }
        public string Teléfono { get; set; }
        public string Email { get; set; }
        public string Dirección { get; set; }
        public string Carrera { get; set; }
        public string TituloMayor { get; set; }
        public string CategoríaProfesoral { get; set; }
        public string FacultadPertene { get; set; }

    }
}
