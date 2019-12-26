using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SISASEPBA.Models
{
    public class APAusencias
    {
        public string Accion { get; set; } = string.Empty;

        public int IdAccionPersonal { get; set; } = 0;
        
        public int IdTipoAP { get; set; } = 0;
        
        public int IdEmpleado { get; set; } = 0;

        [Required(ErrorMessage = "*Campo requerido.")]
        [DisplayName("Días de ausencia:")]
        public int DiasAP { get; set; }

        [Required(ErrorMessage = "*Campo requerido.")]
        [DisplayName("Fecha en la que rige la ausencia:")]
        public DateTime FechaRige { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "*Campo requerido.")]
        [DisplayName("Fecha en la que vence la ausencia:")]
        public DateTime FechaVence { get; set; } = DateTime.Now;

        [StringLength(150, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DisplayName("Observaciones de Acción de Personal:")]
        public string ObservacionesAP { get; set; } = string.Empty;
        
        public DateTime FechaDeAprobacion { get; set; } = DateTime.Now;

        public string UsuarioDeAprobacion { set; get; } = string.Empty;

        public DateTime FechaDeAplicacion { get; set; } = DateTime.Now;

        public string UsuarioDeAplicacion { set; get; } = string.Empty;

        public DateTime FechaDeCancelacion { get; set; } = DateTime.Now;

        public string UsuarioDeCancelacion { set; get; } = string.Empty;

        public DateTime FechaDeDenegacion { get; set; } = DateTime.Now;

        public string UsuarioDeDenegacion { set; get; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        public string UsuarioModificacion { get; set; } = string.Empty;
        
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}