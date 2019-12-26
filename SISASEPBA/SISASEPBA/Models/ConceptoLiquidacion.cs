using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class ConceptoLiquidacion
    {
        public string Accion { get; set; } = string.Empty;

        public int IdConceptoLiquidacion { get; set; } = 0;
        public int IdConcepto { get; set; } = 0;

        [DisplayName("Fecha de liquidación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DataType(DataType.Date)]
        public DateTime FechaLiquidacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "*Campo requerido.")]
        public string Comentarios { get; set; } = string.Empty;

        [DisplayName("Número de liquidación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int NumeroLiquidacion { get; set; } = 0;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }
}