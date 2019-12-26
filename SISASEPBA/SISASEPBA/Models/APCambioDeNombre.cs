using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class APCambioDeNombre
    {
        public int IdAccionPersonal { get; set; } = 0;

        public int IdTipoAP { get; set; } = 0;

        public int IdEmpleado { get; set; } = 0;

        [DisplayName("Primer nombre:")]
        public string EmpleadoPrimerNombre { get; set; } = string.Empty;

        [DisplayName("Segundo nombre:")]
        public string EmpleadoSegundoNombre { get; set; } = string.Empty;

        [DisplayName("Primer apellido:")]
        public string EmpleadoPrimerApellido { get; set; } = string.Empty;

        [DisplayName("Segundo apellido:")]
        public string EmpleadoSegundoApellido { get; set; } = string.Empty;

        [StringLength(150, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Observaciones de acción de personal:")]
        [Required(ErrorMessage = "*Campo requerido.")]
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