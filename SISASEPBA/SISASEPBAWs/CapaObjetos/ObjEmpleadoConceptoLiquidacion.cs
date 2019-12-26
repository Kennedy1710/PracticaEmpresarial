using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjEmpleadoConceptoLiquidacion
    {
        public string Accion { get; set; } = string.Empty;
        public int IdConceptoLiquidacion { get; set; } = 0;
        public int IdEmpleado { get; set; } = 0;
        public DateTime FechaLiquidacion { get; set; } = DateTime.Now;
        public int MontoCalculado { get; set; } = 0;
        public int MontoPagar { get; set; } = 0;
        public string Observaciones { get; set; } = string.Empty;
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;




    }
}