using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjNominasHistorico
    {
        public string Accion { get; set; } = string.Empty;
        public int IdNomina { get; set; } = 0;
        public int Consecutivo { get; set; } = 0;
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = DateTime.Now;
        public DateTime Periodo { get; set; } = DateTime.Now;
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public DateTime FechaCalculo { get; set; } = DateTime.Now;
        public string UsuarioAprobacion { get; set; } = string.Empty;
        public DateTime FechaAprobacion { get; set; } = DateTime.Now;
        public string UsuarioAplicacion { get; set; } = string.Empty;
        public DateTime FechaAplicacion{ get; set; } = DateTime.Now;
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;



    }
}