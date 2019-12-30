using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjCapacitaciones
    {

        public string Accion { get; set; } = string.Empty;

        public int IdCapacitacionEmpleado { get; set; } = 0;

        public int IdTipoCapacitacion { get; set; } = 0;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public DateTime FechaInicio { get; set; } = DateTime.Now;

        public DateTime FechaFinalizacion { get; set; } = DateTime.Now;

        public int CantidadHoras { get; set; } = 0;

        public string NombreCapacitacion { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string PrimerNombreDelCapacitador { get; set; } = string.Empty;

        public string SegundoNombreDelCapacitador { get; set; } = string.Empty;

        public string PrimerApellidoDelCapacitador { get; set; } = string.Empty;

        public string SegundoApellidoDelCapacitador { get; set; } = string.Empty;

        public string EmpresaCapacitadora { get; set; } = string.Empty;

        public string Origen { get; set; } = string.Empty;

        public string CargoPagoCapacitacion { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public byte[] DocumentoAdjunto { get; set; } = null;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }
}