using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISASEPBA.Models
{
    public class EmpleadoLicencia
    {
        public string Accion { get; set; } = string.Empty;

        public int IdEmpleadoLicencia { get; set; } = 0;

        [DisplayName("Código de empleado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdEmpleado { get; set; } = string.Empty;

        [DisplayName("Tipo de licencia")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdTipoLicencia { get; set; } = string.Empty;


        [DisplayName("Fecha de vencimiento")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaVencimiento { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = false;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}