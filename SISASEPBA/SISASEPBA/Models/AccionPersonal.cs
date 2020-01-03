using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class AccionPersonal
    {
        public string Nombre { get; set; } = string.Empty;

        public string CodigoEmpleado { get; set; } = string.Empty;

        public string AccionDePersonal { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioCreacion { get; set; } = string.Empty;
    }
}