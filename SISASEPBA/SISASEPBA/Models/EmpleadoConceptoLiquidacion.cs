using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class EmpleadoConceptoLiquidacion
    {
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Concepto de liquidación")]
        public int IdConceptoLiquidacion { get; set; } = 0;

        [DisplayName("Empleado")]
        public int IdEmpleado { get; set; } = 0;

        [DisplayName("Fecha de liquidación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DataType(DataType.Date)]
        public DateTime FechaLiquidacion { get; set; } = DateTime.Now;

        [DisplayName("Monto Calculado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int MontoCalculado { get; set; } = 0;

        [DisplayName("Monto a Pagar")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int MontoPagar{ get; set; } = 0;

        [Required(ErrorMessage = "*Campo requerido.")]
        public string Observaciones { get; set; } = string.Empty;
        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;




    }
}