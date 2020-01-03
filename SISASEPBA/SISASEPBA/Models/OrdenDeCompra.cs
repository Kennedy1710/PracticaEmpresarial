using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class OrdenDeCompra
    {
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Órden de compra")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdOrdenCompra { get; set; } = 0;

        [DisplayName("Socio")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdSocio { get; set; } = "0";

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdProveedor { get; set; } = "0";

        [DisplayName("Fecha de emision")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaEmision { get; set; } = DateTime.Now;

        [DisplayName("Descripcion")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Descripcion { get; set; } = string.Empty;

        [DisplayName("Monto total")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int MontoTotal { get; set; } = 0;


        [DisplayName("Número de factura proforma")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int NumeroFacturaProforma { get; set; } = 0;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}