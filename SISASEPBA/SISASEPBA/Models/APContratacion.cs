using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class APContratacion
    {

        public string Accion { get; set; } = string.Empty;

        public int IdAccionPersonal { get; set; } = 0;

        public string IdTipoAP { get; set; } = "0";

        [DisplayName("Departamento: ")]
        public string IdDepartamento { get; set; } = "0";

        [DisplayName("Puesto: ")]
        public string IdPuesto { get; set; } = "0";

        [DisplayName("Nómina: ")]
        public string IdNomina { get; set; } = "0";

        [DisplayName("Forma de pago: ")]
        public string IdFormaPago { get; set; } = "0";

        [DisplayName("Régimen vacacional: ")]
        public string IdRegimenVacacional { get; set; } = "0";

        [DisplayName("Nacionalidad: ")]
        public string IdNacionalidad { get; set; } = "0";

        public string IdEmpleado { get; set; } = "0";

        [DisplayName("Fecha de ingreso: ")]
        public DateTime FechaRige { get; set; } = DateTime.Now;

        [DisplayName("Fecha de salida: ")]
        public DateTime FechaVence { get; set; } = DateTime.Now;

        [DisplayName("Ahorro en la asociación: ")]
        public decimal AhorroAsociacion { set; get; } = 0;

        [DisplayName("Código del empleado:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CodigoEmpleado { set; get; } = String.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Primer nombre del empleado:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string EmpleadoPrimerNombre { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Segundo nombre del empleado:")]
        public string EmpleadoSegundoNombre { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Primer apellido del empleado:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string EmpleadoPrimerApellido { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Segundo apellido del empleado:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string EmpleadoSegundoApellido { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Tipo de identificación:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TipoIdentificacion { set; get; } = string.Empty;

        [DisplayName("Número de identificación:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int NumeroIdentificacion { set; get; } = 0;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Teléfono principal:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TelefonoPrincipal { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Teléfono secundario:")]
        public string TelefonoSecundario { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Teléfono de emergencia:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TelefonoEmergencia { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Contacto de emergencia:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string ContactoEmergencia { set; get; } = string.Empty;

        //[StringLength(3, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Tipo de sangre:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TipoSangre { set; get; } = string.Empty;

        [DisplayName("Fecha de nacimiento:")]
        public DateTime FechaNacimiento { set; get; } = DateTime.Now;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Dirección de domicilio:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string DireccionDomicilio { set; get; } = string.Empty;

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Sexo:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Sexo { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Estado civil:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string EstadoCivil { get; set; } = string.Empty;

        [DisplayName("Estado:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Estado { get; set; } = string.Empty;

        public string SubEstado { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Correo electrónico:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CorreoElectronico { set; get; } = string.Empty;

        [DisplayName("Conyugue dependiente:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool ConyugeDependiente { set; get; } = false;

        [DisplayName("Hijos dependientes:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int HijosDependientes { set; get; } = 0;

        [DisplayName("Número de asegurado:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string NumeroAsegurado { set; get; } = string.Empty;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Salario referencia:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int SalarioReferencia { set; get; } = 0;

        public byte[] Foto { set; get; } = null;

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Observaciones generales:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string ObservacionesGenerales { set; get; } = string.Empty;

        [StringLength(150, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [DisplayName("Observaciones de acción de personal:")]
        [Required(ErrorMessage = "*Campo requerido.")]
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