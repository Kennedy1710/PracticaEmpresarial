using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjEmpleado
    {
        public string Accion { get; set; } = string.Empty;

        public int IdEmpleado { get; set; } = 0;

        public int IdNacionalidad { get; set; } = 0;

        public int IdDepartamento { get; set; } = 0;

        public int IdPuesto { get; set; } = 0;

        public int IdNomina { get; set; } = 0;

        public int IdFormaPago { get; set; } = 0;

        public int IdRegimenVacacional { get; set; } = 0;

        public string CodigoEmpleado { get; set; } = string.Empty;

        public string PrimerNombre { get; set; } = string.Empty;

        public string SegundoNombre { get; set; } = string.Empty;

        public string PrimerApellido { get; set; } = string.Empty;

        public string SegundoApellido { get; set; } = string.Empty;

        public string TipoIdentificacion { get; set; } = string.Empty;

        public int NumeroIdentificacion { get; set; } = 0;

        public decimal AhorroAsociacion { get; set; } = 0;

        public string TelefonoPrincipal { get; set; } = string.Empty;

        public string TelefonoSecundario { get; set; } = string.Empty;

        public string TelefonoEmergencia { get; set; } = string.Empty;

        public string ContactoEmergencia { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        public DateTime FechaSalida { get; set; } = DateTime.Now;

        public string TipoDeSangre { get; set; } = string.Empty;

        public string DireccionDomicilio { get; set; } = string.Empty;

        public string Sexo { get; set; } = string.Empty;

        public string EstadoCivil { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string SubEstado { get; set; } = string.Empty;

        public string CorreoElectronico { get; set; } = string.Empty;

        public bool ConyugeDependiente { get; set; } = false;

        public int HijosDependientes { get; set; } = 0;

        public string NumeroAsegurado { get; set; } = string.Empty;

        public int VacacionesPendientes { get; set; } = 0;

        public DateTime UltimoCambioVac { get; set; } = DateTime.Now;

        public decimal SalarioReferencia { get; set; } = 0;

        public byte[] Foto { get; set; } = null;

        public string ObservacionesGenerales { get; set; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}