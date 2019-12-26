using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjAccionDePersonal
    {
       
        public string Accion { get; set; } = string.Empty;
       
        public int IdAccionPersonal { get; set; } = 0;
        
        public int IdTipoAP { get; set; } = 0;
      
        public int IdRegimenVacacional { get; set; } = 0;
       
        public int IdEmpleado { get; set; } = 0;
       
        public int IdNacionalidad { get; set; } = 0;
       
        public int IdDepartamento { get; set; } = 0;
       
        public int IdPuesto { get; set; } = 0;
       
        public int IdNomina { get; set; } = 0;
        
        public int IdFormaPago { get; set; } = 0;
       
        public string EstadoAP { get; set; } = string.Empty;
       
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
     
        public string UsuarioCreacion { get; set; } = string.Empty;
      
        public DateTime FechaAprobacion { get; set; } = DateTime.Now;
        
        public string UsuarioAprobacion { get; set; } = string.Empty;
      
        public DateTime FechaAplicacion { get; set; } = DateTime.Now;
       
        public string UsuarioAplicacion { get; set; } = string.Empty;
       
        public DateTime FechaCancelacion { get; set; } = DateTime.Now;
       
        public string UsuarioCancelacion { get; set; } = string.Empty;
       
        public DateTime FechaDenegacion { get; set; } = DateTime.Now;
       
        public string UsuarioDenegacion { get; set; } = string.Empty;
       
        public int DiasAP { get; set; } = 0;
        
        public DateTime FechaRige { get; set; } = DateTime.Now;
       
        public DateTime FechaVence { get; set; } = DateTime.Now;
       
        public int SaldoVacaciones { get; set; } = 0;
       
        public decimal AhorroAsociacion { get; set; } = 0;
        
        public string EmpleadoPrimerNombre { get; set; } = string.Empty;
     
        public string EmpleadoSegundoNombre { get; set; } = string.Empty;
        
        public string EmpleadoPrimerApellido { get; set; } = string.Empty;
      
        public string EmpleadoSegundoApellido { get; set; } = string.Empty;
       
        public string TipoIdentificacion { get; set; } = string.Empty;
       
        public int NumeroIdentificacion { get; set; } = 0;
       
        public string TelefonoPrincipal { get; set; } = string.Empty;
      
        public string TelefonoSecundario { get; set; } = string.Empty;
       
        public string TelefonoEmergencia { get; set; } = string.Empty;
      
        public string ContactoEmergencia { get; set; } = string.Empty;
     
        public DateTime FechaNacimineto { get; set; } = DateTime.Now;
      
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
      
        public DateTime FechaSalida { get; set; } = DateTime.Now;
      
        public string TipoSangre { get; set; } = string.Empty;
     
        public string DireccionDomicilio { get; set; } = string.Empty;
      
        public string Sexo { get; set; } = string.Empty;
       
        public string EstadoCivil { get; set; } = string.Empty;
       
        public int Estado { get; set; } = 0;
       
        public string SubEstado { get; set; } = string.Empty;
      
        public string CorreoElectronico { get; set; } = string.Empty;
       
        public bool ConyugeDependiente { get; set; } = false;
       
        public int HijosDependientes { get; set; } = 0;
   
        public string NumeroAsegurado { get; set; } = string.Empty;
     
        public int VacacionesPendientes { get; set; } = 0;
       
        public DateTime UltimoCambiovacacional { get; set; } = DateTime.Now;
     
        public int SalarioReferencia { get; set; } = 0;
     
        public byte[] Foto { get; set; } = null;
     
        public string ObservacionesGenerales { get; set; } = string.Empty;
      
        public string ObservacionesAP { get; set; } = string.Empty;
        
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
      
        public string UsuarioModificacion { get; set; } = string.Empty;
    }
}