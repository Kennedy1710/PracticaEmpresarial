using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjDocumentos
    {
        public string Accion { get; set; } = string.Empty;
        public int IdDocumento { get; set; } = 0;
        public int IdTipoDocumento { get; set; } = 0;
        public string TituloDocumento { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRige { get; set; } = DateTime.Now;
        public DateTime FechaVence { get; set; } = DateTime.Now;
        public string Estado { get; set; } = string.Empty;

        public byte[] DocumentoAdjunto = null;
        public int IdRenovacion { get; set; } = 0;
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }
}