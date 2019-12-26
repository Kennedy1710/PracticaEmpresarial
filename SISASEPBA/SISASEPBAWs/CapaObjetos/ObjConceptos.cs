using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjConceptos
    {
        public string Accion { get; set; } = string.Empty;

        public int IdConcepto { get; set; } = 0;

        public string Concepto { get; set; } = string.Empty;

        public string TipoConcepto { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Unidad { get; set; } = string.Empty;

        public bool Salarial { get; set; } = false;

        public bool Fijo { get; set; } = false;

        public bool Liquidable { get; set; } = false;

        public bool Excluyente { get; set; } = false;

        public bool CantidadEditable { get; set; } = false;
        public bool MontoEditable { get; set; } = false;

        public bool UsaCantidad { get; set; } = false;

        public bool UsaMonto { get; set; } = false;

        public bool FormulaDefinida { get; set; } = false;

        public bool ImprimeComprobante { get; set; } = false;

        public bool ImprimeAcumulado { get; set; } = false;

        public decimal FactorRedondeo { get; set; } = 0;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }
}