using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjEmpleadoConceptoNomina
    {
        public string Accion { get; set; } = string.Empty;

        public int IdEmpleado { get; set; } = 0;
        public int IdConcepto { get; set; } = 0;
        public int IdNomina { get; set; } = 0;
        public int IdConceptoLiquidacion { get; set; } = 0;
        public int ConsecutivoNomina { get; set; } = 0;
        public int Cantidad { get; set; } = 0;
        public int Monto { get; set; } = 0;
        public int Total { get; set; } = 0;
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}