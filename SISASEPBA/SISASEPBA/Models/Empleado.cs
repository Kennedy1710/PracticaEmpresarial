using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SISASEPBA.Models
{
    public class Empleado
    {
        public string Accion { get; set; } = string.Empty;

        public int IdEmpleado { get; set; } = 0;

        [DisplayName("Nacionalidad")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdNacionalidad { get; set; } = string.Empty;

        [DisplayName("Departamento")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdDepartamento { get; set; } = string.Empty;

        [DisplayName("Puesto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdPuesto { get; set; } = string.Empty;

        [DisplayName("Nómina")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdNomina { get; set; } = string.Empty;

        [DisplayName("Forma de pago")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdFormaPago { get; set; } = string.Empty;

        [DisplayName("Regimen vacacional")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdRegimenVacacional { get; set; } = string.Empty;

        [DisplayName("Código de empleado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CodigoEmpleado { get; set; } = string.Empty;

        [DisplayName("Primer nombre")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string PrimerNombre { get; set; } = string.Empty;

        [DisplayName("Segundo nombre")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string SegundoNombre { get; set; } = string.Empty;

        [DisplayName("Primer apellido")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string PrimerApellido { get; set; } = string.Empty;

        [DisplayName("Segundo apellido")]
        public string SegundoApellido { get; set; } = string.Empty;

        [DisplayName("Tipo de identificación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TipoIdentificacion { get; set; } = string.Empty;

        [DisplayName("Número de identificación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int NumeroIdentificacion { get; set; } = 0;

        [DisplayName("Ahorro en la asociación")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public decimal AhorroAsociacion { get; set; } = 0;

        [DisplayName("Teléfono principal")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TelefonoPrincipal { get; set; } = string.Empty;

        [DisplayName("Departamento")]
        public string TelefonoSecundario { get; set; } = string.Empty;

        [DisplayName("Teléfono de emergencia")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TelefonoEmergencia { get; set; } = string.Empty;

        [DisplayName("Contacto de emergencia")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string ContactoEmergencia { get; set; } = string.Empty;

        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        [DisplayName("Fecha de ingreso")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        [DisplayName("Fecha de salida")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaSalida { get; set; } = DateTime.Now;

        [DisplayName("Tipo de sangre")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TipoDeSangre { get; set; } = string.Empty;

        [DisplayName("Dirección a domicilio")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string DireccionDomicilio { get; set; } = string.Empty;

        [DisplayName("Sexo")]
        public string Sexo { get; set; } = string.Empty;

        [DisplayName("Estado civil")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string EstadoCivil { get; set; } = string.Empty;

        [DisplayName("Estado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Estado { get; set; } = string.Empty;

        [DisplayName("Subestados")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string SubEstado { get; set; } = string.Empty;

        [DisplayName("Correo electrónico")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CorreoElectronico { get; set; } = string.Empty;

        [DisplayName("¿Cónyuge dependiente?")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool ConyugeDependiente { get; set; } = false;

        [DisplayName("Hijos dependientes")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int HijosDependientes { get; set; } = 0;

        [DisplayName("Número de asegurado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string NumeroAsegurado { get; set; } = string.Empty;

        [DisplayName("Vacaciones pendientes")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int VacacionesPendientes { get; set; } = 0;

        [DisplayName("Último cambio vacacional")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime UltimoCambioVac { get; set; } = DateTime.Now;

        [DisplayName("Salario de referencia")]
        public decimal SalarioReferencia { get; set; } = 0;

        [DisplayName("Foto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public byte[] Foto { get; set; } = null;

        [DisplayName("Observaciones generales")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string ObservacionesGenerales { get; set; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public string NombreCompleto { get; set; } = string.Empty;
    }
}