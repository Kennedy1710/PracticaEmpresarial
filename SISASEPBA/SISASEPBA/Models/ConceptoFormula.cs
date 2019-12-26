using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class ConceptoFormula
    {
        public string Accion { get; set; } = string.Empty;

        public int IdConceptoFormula { get; set; } = 0;

        public int IdConcepto { get; set; } = 0;


        [Required(ErrorMessage = "*Campo requerido.")]
        public int Secuencia { get; set; } = 0;

        [DisplayName("Valor inicial")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int ValorInicial { get; set; } = 0;

        [DisplayName("Valor final")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int ValorFinal { get; set; } = 0;

        [DisplayName("Cantidad de monto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int CantidadMonto { get; set; } = 0;

        [DisplayName("Nivel de formula")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int NivelFormula { get; set; } = 0;

        [DisplayName("Usa cantidad")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool UsaCantidad { get; set; } = false;

        [DisplayName("Usa monto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool UsaMonto { get; set; } = false;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}