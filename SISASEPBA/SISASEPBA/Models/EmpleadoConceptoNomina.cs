using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class EmpleadoConceptoNomina
    {
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Empleado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdEmpleado { get; set; } = 0;

        [DisplayName("Concepto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdConcepto { get; set; } = 0;

        [DisplayName("Nómina")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdNomina { get; set; } = 0;

        [DisplayName("Concepto por liquidación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdConceptoLiquidacion { get; set; } = 0;

        [DisplayName("Consecutivo nómina")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int ConsecutivoNomina { get; set; } = 0;
        public int Cantidad { get; set; } = 0;
        public int Monto { get; set; } = 0;
        public int Total { get; set; } = 0;
        public string UsuarioCreacion { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}