using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Nacionalidad
    {
        public string Accion { get; set; } = string.Empty;

        public int IdNacionalidad { get; set; } = 0;

        public string Alias { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}