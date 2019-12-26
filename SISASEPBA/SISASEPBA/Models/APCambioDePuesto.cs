using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class APCambioDePuesto
    {
        public string Accion { get; set; } = string.Empty;

        public int IdAccionPersonal { get; set; } = 0;

        public int IdTipoAP { get; set; } = 0;

        public int IdEmpleado { get; set; } = 0;

        [DisplayName("Departamento: ")]
        public string IdDepartamento { get; set; } = string.Empty;

        [DisplayName("Puesto: ")]
        public string IdPuesto { get; set; } = string.Empty;

        [DisplayName("Nómina: ")]
        public string IdNomina { get; set; } = string.Empty;

        [DisplayName("Salario de referencia: ")]
        public decimal SalarioReferencia { get; set; } = 0;

        [DisplayName("Fecha en la que rige: ")]
        public DateTime FechaRige { get; set; } = DateTime.Now;

        [StringLength(150, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DisplayName("Observaciones de acción de personal: ")]
        public string ObservacionesAP { get; set; } = string.Empty;
        
        public DateTime FechaDeAprobacion { get; set; } = DateTime.Now;
        
        public string UsuarioDeAprobacion { set; get; } = string.Empty;
        
        public DateTime FechaDeAplicacion { get; set; } = DateTime.Now;
        
        public string UsuarioDeAplicacion { set; get; } = string.Empty;
        
        public DateTime FechaDeCancelacion { get; set; } = DateTime.Now;
        
        public string UsuarioDeCancelacion { set; get; } = string.Empty;
        
        public DateTime FechaDeDenegacion { get; set; } = DateTime.Now;
        
        public string UsuarioDeDenegacion { set; get; } = string.Empty;
        
        public string UsuarioCreacion { get; set; } = string.Empty;
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        public string UsuarioModificacion { get; set; } = string.Empty;
        
        public DateTime FechaModificacion { get; set; } = DateTime.Now;


    }
}