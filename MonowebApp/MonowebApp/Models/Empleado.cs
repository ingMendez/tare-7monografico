using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonowebApp.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string Codigo { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Ocupación { get; set; }
        public string TipoSangre { get; set; }
        public string Nacionalidad { get; set; }
        public string Religión { get; set; }
        public string Teléfono { get; set; }
        public string Email { get; set; }
        public string Dirección { get; set; }
        public string SalarioM { get; set; }
        public string DepartamentoPertene { get; set; }
        public string NombreContactSos { get; set; }
        public string TelefonoContactSos { get; set; }
        public string AfpPertenece { get; set; }
        public string ArsPertenece { get; set; }
        public string Observaciones { get; set; }


    }
}
