using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class Proveedor
    {
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int IdProveedor { get; set; } = 0;

        [DisplayName("Número de cédula")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int NumeroCedula { get; set; } = 0;


        [DisplayName("Nombre fantasía")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string NombreFantasia { get; set; } = string.Empty;

        [DisplayName("Nombre real")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string NombreReal { get; set; } = string.Empty;


        [DisplayName("Primer nombre apoderado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string PrimerNombreApoderado { get; set; } = string.Empty;


        [DisplayName("Segundo nombre apoderado")]
        public string SegundoNombreApoderado { get; set; } = string.Empty;


        [DisplayName("Primer apellido apoderado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string PrimerApellidoApoderado { get; set; } = string.Empty;

        [DisplayName("Segundo apellido apoderado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string SegundoApellidoApoderado { get; set; } = string.Empty;

        [DisplayName("Cédula de apoderado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public int CedulaApoderado { get; set; } = 0;

        [DisplayName("Fecha rige")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaRige { get; set; } = DateTime.Now;


        [DisplayName("Fecha vence")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaVence { get; set; } = DateTime.Now;


        [DisplayName("Estado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool Estado { get; set; } = false;


        [DisplayName("Descripción")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string DescripcionConvenio { get; set; } = string.Empty;


        [DisplayName("Beneficio de asociado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string BeneficioAsociado { get; set; } = string.Empty;


        [DisplayName("Beneficio ASEPBA")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string BeneficioASEPBA { get; set; } = string.Empty;


        [DisplayName("Documento adjunto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public byte[] DocumentoAdjunto { get; set; } = null;


        [DisplayName("Persona de contacto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string PersonaContacto { get; set; } = string.Empty;


        [DisplayName("Correo de contacto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CorreoContacto { get; set; } = string.Empty;


        [DisplayName("Teléfono de contacto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TelefonoContacto { get; set; } = string.Empty;


        [DisplayName("Segunda persona de contacto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string SegundaPersonaContacto { get; set; } = string.Empty;

        [DisplayName("Segundo correo de contacto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string CorreoSegundoContacto { get; set; } = string.Empty;

        [DisplayName("Segundo teléfono de contacto")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string TelefonoSegundoContacto { get; set; } = string.Empty;


        [DisplayName("Logotipo")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public byte[] Logo { get; set; } = null;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}