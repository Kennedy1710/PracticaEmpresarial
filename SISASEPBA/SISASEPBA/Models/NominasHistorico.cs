using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SISASEPBA.Models
{
    public class NominasHistorico
    {
        public string Accion { get; set; } = string.Empty;
        public int IdNomina { get; set; } = 0;
        public int Consecutivo { get; set; } = 0;

        [DisplayName("Fecha de inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        [DisplayName("Fecha de finalización")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; } = DateTime.Now;
        [DisplayName("Periodo")]
        [DataType(DataType.Date)]
        public DateTime Periodo { get; set; } = DateTime.Now;
        [DisplayName("Fecha de pago")]
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; } = DateTime.Now;
        [DisplayName("Fecha de cálculo")]
        [DataType(DataType.Date)]
        public DateTime FechaCalculo { get; set; } = DateTime.Now;
        [DisplayName("Usuario de aprobación")]
        public string UsuarioAprobacion { get; set; } = string.Empty;
        [DisplayName("Fecha de aprobación")]
        [DataType(DataType.Date)]
        public DateTime FechaAprobacion { get; set; } = DateTime.Now;
        [DisplayName("Usuario de aplicación")]
        public string UsuarioAplicacion { get; set; } = string.Empty;
        [DisplayName("Fecha de aplicación")]
        [DataType(DataType.Date)]
        public DateTime FechaAplicacion { get; set; } = DateTime.Now;
        [DisplayName("Usuario creación")]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DisplayName("Fecha de creacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DisplayName("Usurio de modificación")]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DisplayName("Fecha de modificación")]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}