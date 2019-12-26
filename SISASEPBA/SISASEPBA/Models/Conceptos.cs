using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Conceptos
    {
        public string Accion { get; set; } = string.Empty;

        public int IdConcepto { get; set; } = 0;

        [Required(ErrorMessage = "*Campo requerido.")]
        public string Concepto { get; set; } = string.Empty;

        [DisplayName("Tipo de concepto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TipoConcepto { get; set; } = string.Empty;

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "*Campo requerido.")]
        public string Unidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "*Campo requerido.")]

        public bool Salarial { get; set; } = false;

        [Required(ErrorMessage = "*Campo requerido.")]

        public bool Fijo { get; set; } = false;

        [Required(ErrorMessage = "*Campo requerido.")]

        public bool Liquidable { get; set; } = false;

        [Required(ErrorMessage = "*Campo requerido.")]

        public bool Excluyente { get; set; } = false;

        [DisplayName("Cantidad editable")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool CantidadEditable { get; set; } = false;

        [DisplayName("Monto editable")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool MontoEditable { get; set; } = false;

        [DisplayName("Usa cantidad")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool UsaCantidad { get; set; } = false;

        [DisplayName("Usa monto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool UsaMonto { get; set; } = false;

        [DisplayName("Fórmula definida")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool FormulaDefinida { get; set; } = false;

        [DisplayName("Imprimir comprobante")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool ImprimeComprobante { get; set; } = false;

        [DisplayName("Imprimir acumulado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool ImprimeAcumulado { get; set; } = false;

        [DisplayName("Factor redondeo")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public decimal FactorRedondeo { get; set; } = 0;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}