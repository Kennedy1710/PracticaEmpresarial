using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Nomina
    {
        public string Accion { get; set; } = string.Empty;

        public int IdNomina { get; set; } = 0;

        [DisplayName("Alias")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Alias { get; set; } = string.Empty;

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Descripcion { get; set; } = string.Empty;


        [DisplayName("Tipo de nómina")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TipoNomina { get; set; } = string.Empty;

        public int Consecutivo { get; set; } = 0;
        public string Estado { get; set; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}