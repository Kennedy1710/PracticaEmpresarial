using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class EmpleadoConceptos
    {
        public string Accion { get; set; } = string.Empty;

        public int IdConcepto { get; set; } = 0;

        [DisplayName("Código empleado")]
        public int IdEmpleado { get; set; } = 0;

        [DisplayName("Número de cuotas")]
        public int NumeroCuotas { get; set; } = 0;

        [DisplayName("Cuotas aplicadas")]
        public int CuotasAplicadas { get; set; } = 0;

        [DisplayName("Saldo inicial")]
        public int SaldoInicial { get; set; } = 0;

        public int Saldo { get; set; } = 0;

        public int Acumulado { get; set; } = 0;

        [DisplayName("Fecha de última aplicación")]
        [DataType(DataType.Date)]
        public DateTime FechaUltimaAplicacion { get; set; } = DateTime.Now;


        [DisplayName("Fecha de próxima aplicación")]
        [DataType(DataType.Date)]
        public DateTime FechaProximaAplicacion { get; set; } = DateTime.Now;

        [DisplayName("Fecha de vencimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; } = DateTime.Now;

        public int Cantidad { get; set; } = 0;

        public int Monto { get; set; } = 0;

        public string Comentarios { get; set; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}