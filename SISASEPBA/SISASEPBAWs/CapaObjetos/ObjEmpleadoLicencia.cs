using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjEmpleadoLicencia
    {
        public string Accion { get; set; } = string.Empty;

        public int IdEmpleadoLicencia { get; set; } = 0;

        public int IdEmpleado { get; set; } = 0;

        public int IdTipoLicencia { get; set; } = 0;

        public DateTime FechaVencimiento { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = false;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}