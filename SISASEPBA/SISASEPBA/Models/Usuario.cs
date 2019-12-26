using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISASEPBA.Models
{
    public class Usuario
    {
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Código")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CodUsuario { get; set; } = string.Empty;

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Nombre { get; set; } = string.Empty;

        [DefaultValue(0)]
        [Required(ErrorMessage = "*Campo requerido.")]
        [RegularExpression("^[0-9-A-Z]*$", ErrorMessage = "Solo se permiten numeros, letras mayusculas sin espacios.")]
        public string Empresa { get; set; }

        [DisplayName("Es Empleado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool EsEmpleado { get; set; } = false;

        [DisplayName("Tipo Inicio Sesión")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TipoInicioSesion { get; set; } = string.Empty;


        [DisplayName("Código Empleado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CodEmpleado { get; set; } = string.Empty;

        [RegularExpression(@"^.{8,}$", ErrorMessage = "La contraseña debe contener mínimo 8 caracteres")]
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;

        [RegularExpression(@"^.{8,}$", ErrorMessage = "La contraseña debe contener mínimo 8 caracteres")]
        [DisplayName("Confirmar Contraseña")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [System.ComponentModel.DataAnnotations.Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        [DataType(DataType.Password)]
        public string ConfirmarContrasena { get; set; } = string.Empty;

        [DisplayName("Contraseña vence")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool ContrasenaVence { get; set; } = false;


        [DisplayName("Cambiar próximo inicio")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool CambioProximoInicio { get; set; } = false;


        [DisplayName("Dias Vencimiento")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 0")]
        public int DiasVencimiento { get; set; } = 0;


        [DisplayName("Maximo Intentos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 0")]
        public int MaximoIntentos { get; set; } = 0;


        [DisplayName("Correo")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo no valido!")]
        public string Correo { get; set; } = string.Empty;


        [Required(ErrorMessage = "*Campo requerido.")]
        public string Estado { get; set; } = string.Empty;

        [Display(AutoGenerateField = false)]
        public string UsuarioSesion { get; set; } = string.Empty;
    }
}
