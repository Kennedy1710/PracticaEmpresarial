using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjOrdenCompra
    {
        public string Accion { get; set; } = string.Empty;

        public int IdOrdenCompra { get; set; } = 0;

        public int IdSocio { get; set; } = 0;

        public int IdProveedor { get; set; } = 0;

        public DateTime FechaEmision { get; set; } = DateTime.Now;

        public string Descripcion { get; set; } = string.Empty;

        public int MontoTotal { get; set; } = 0;

        public int NumeroFacturaProforma { get; set; } = 0;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}