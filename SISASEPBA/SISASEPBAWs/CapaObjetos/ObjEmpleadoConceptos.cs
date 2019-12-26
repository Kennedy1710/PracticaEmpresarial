using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjEmpleadoConceptos
    {
        public string Accion { get; set; } = string.Empty;
        public int IdConcepto { get; set; } = 0;
        public int IdEmpleado { get; set; } = 0;
        public int NumeroCuotas { get; set; } = 0;
        public int CuotasAplicadas { get; set; } = 0;
        public int SaldoInicial { get; set; } = 0;
        public int Saldo { get; set; } = 0;
        public int Acumulado { get; set; } = 0;
        public DateTime FechaUltimaAplicacion { get; set; } = DateTime.Now;
        public DateTime FechaProximaAplicacion { get; set; } = DateTime.Now;
        public DateTime FechaVencimiento{ get; set; } = DateTime.Now;
        public int Cantidad { get; set; } = 0;
        public int Monto { get; set; } = 0;
        public string Comentarios { get; set; } = string.Empty;
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}