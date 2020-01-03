using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Socio
    {
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Socio")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdSocio { get; set; } = 0;

        [DisplayName("Número de identificación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int NumeroIdentificacion { get; set; } = 0;

        [DisplayName("Primer nombre")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string PrimerNombreSocio { get; set; } = string.Empty;

        [DisplayName("Segundo nombre")]
        public string SegundoNombreSocio { get; set; } = string.Empty;

        [DisplayName("Primer apellido")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string PrimerApellidoSocio { get; set; } = string.Empty;

        [DisplayName("Segundo apellido")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string SegundoApellidoSocio { get; set; } = string.Empty;


        [DisplayName("Empresa")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Empresa { get; set; } = string.Empty;

        [DisplayName("Fecha ingreso a la asociación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaIngresoAsociacion { get; set; } = DateTime.Now;


        [DisplayName("Estado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool Estado { get; set; } = false;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}