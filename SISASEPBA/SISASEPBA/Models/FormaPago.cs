using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class FormaPago
    {
        public string Accion { get; set; } = string.Empty;

        public int IdFormaPago { get; set; } = 0;

        public string Alias { get; set; } = string.Empty;

        public bool Estado { get; set; } = false;

        public string Descripcion { get; set; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}