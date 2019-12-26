using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjConceptoLiquidacion
    {
        public string Accion { get; set; } = string.Empty;

        public int IdConceptoLiquidacion { get; set; } = 0;
        public int IdConcepto { get; set; } = 0;
        public DateTime FechaLiquidacion { get; set; } = DateTime.Now;

        public string Comentarios { get; set; } = string.Empty;

        public int NumeroLiquidacion { get; set; } = 0;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}