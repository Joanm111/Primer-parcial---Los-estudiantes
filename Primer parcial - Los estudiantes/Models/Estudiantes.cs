using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Primer_parcial___Los_estudiantes.Models
{
    public partial class Estudiantes
    {
        public string Matricula { get; set; }
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Asignatura { get; set; }
        public string Periodo { get; set; }
        public string CodAsignatura { get; set; }
        public int? Pp1 { get; set; }
        public int? Pp2 { get; set; }
        public int? Pp3 { get; set; }
        public int? Ano { get; set; }
    }
}
