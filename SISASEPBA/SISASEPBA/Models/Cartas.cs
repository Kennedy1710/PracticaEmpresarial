using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Cartas
    {
        public string Accion { get; set; } = string.Empty;


        [DisplayName("Carta")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdCarta { get; set; } = 0;


        [DisplayName("Socio")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdSocio { get; set; } = "0";


        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdProveedor { get; set; } = "0";

        [DisplayName("Fecha")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [DisplayName("Cantidad de impresiones")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int CantidadImpresiones { get; set; } = 0;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}