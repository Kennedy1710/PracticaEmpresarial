using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Capacitacion
    {

        public string Accion { get; set; } = string.Empty;

        public int IdCapacitacionEmpleado { get; set; } = 0;

        [DisplayName("Tipo de Capacitación")]
        public string IdTipoCapacitacion { get; set; } = string.Empty;

        [DisplayName("Fecha de registro:")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [DisplayName("Fecha de inicio:")]
        public DateTime FechaInicio { get; set; } = DateTime.Now;

        [DisplayName("Fecha de finalización:")]
        public DateTime FechaFinalizacion { get; set; } = DateTime.Now;

        [DisplayName("Cantidad de horas:")]
        public int CantidadHoras { get; set; } = 0;

        [DisplayName("Nombre de la Capacitación")]
        public string NombreCapacitacion { get; set; } = string.Empty;

        [DisplayName("Descripción:")]
        public string Descripcion { get; set; } = string.Empty;

        [DisplayName("Primer nombre:")]
        public string PrimerNombreDelCapacitador { get; set; } = string.Empty;

        [DisplayName("Segundo nombre:")]
        public string SegundoNombreDelCapacitador { get; set; } = string.Empty;

        [DisplayName("Primer apellido:")]
        public string PrimerApellidoDelCapacitador { get; set; } = string.Empty;

        [DisplayName("Segundo apellido:")]
        public string SegundoApellidoDelCapacitador { get; set; } = string.Empty;

        [DisplayName("Empresa Capacitadora")]
        public string EmpresaCapacitadora { get; set; } = string.Empty;

        [DisplayName("Origen de la capacitación:")]
        public string Origen { get; set; } = string.Empty;

        [DisplayName("Encargado de pago:")]
        public string CargoPagoCapacitacion { get; set; } = string.Empty;

        [DisplayName("Estado")]
        public string Estado { get; set; } = string.Empty;

        [DisplayName("Documento adjunto:")]
        public byte[] DocumentoAdjunto { get; set; } = null;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;
 
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }
}