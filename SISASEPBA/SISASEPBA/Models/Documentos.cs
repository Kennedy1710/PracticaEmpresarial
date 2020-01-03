using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Documentos
    {
        public string Accion { get; set; } = string.Empty;
        public int IdDocumento { get; set; } = 0;

        [DisplayName("Tipo de Documento")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdTipoDocumento { get; set; } = 0;

        [DisplayName("Título del documento")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TituloDocumento { get; set; } = string.Empty;

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Descripcion { get; set; } = string.Empty;

        [DisplayName("Fecha en la que rige")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DataType(DataType.Date)]
        public DateTime FechaRige { get; set; } = DateTime.Now;

        [DisplayName("Fecha en la que vence")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DataType(DataType.Date)]
        public DateTime FechaVence { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "*Campo requerido.")]
        public string Estado { get; set; } = string.Empty;

        [DisplayName("Documento adjunto")]
        public byte[] DocumentoAdjunto { get; set; } = null;

        [DisplayName("Renovación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdRenovacion { get; set; } = 0;
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;



    }
}