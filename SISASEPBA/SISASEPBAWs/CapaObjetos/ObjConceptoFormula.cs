using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjConceptoFormula
    {
        public string Accion { get; set; } = string.Empty;

        public int IdConceptoFormula { get; set; } = 0;
        public int IdConcepto { get; set; } = 0;

        public int Secuencia { get; set; } = 0;

        public int ValorInicial { get; set; } = 0;

        public int ValorFinal { get; set; } = 0;

        public int CantidadMonto { get; set; } = 0;

        public int NivelFormula { get; set; } = 0;

        public bool UsaCantidad { get; set; } = false;

        public bool UsaMonto { get; set; } = false;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}