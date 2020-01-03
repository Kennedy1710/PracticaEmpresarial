using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjProveedor
    {
        public string Accion { get; set; } = string.Empty;

        public int IdProveedor { get; set; } = 0;

        public int NumeroCedula { get; set; } = 0;

        public string NombreFantasia { get; set; } = string.Empty;

        public string NombreReal { get; set; } = string.Empty;

        public string PrimerNombreApoderado { get; set; } = string.Empty;

        public string SegundoNombreApoderado { get; set; } = string.Empty;

        public string PrimerApellidoApoderado { get; set; } = string.Empty;

        public string SegundoApellidoApoderado { get; set; } = string.Empty;

        public int CedulaApoderado { get; set; } = 0;

        public DateTime FechaRige { get; set; } = DateTime.Now;

        public DateTime FechaVence { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = false;

        public string DescripcionConvenio { get; set; } = string.Empty;

        public string BeneficioAsociado { get; set; } = string.Empty;

        public string BeneficioASEPBA { get; set; } = string.Empty;

        public byte[] DocumentoAdjunto { get; set; } = null;

        public string PersonaContacto { get; set; } = string.Empty;

        public string CorreoContacto { get; set; } = string.Empty;

        public string TelefonoContacto { get; set; } = string.Empty;

        public string SegundaPersonaContacto { get; set; } = string.Empty;

        public string CorreoSegundoContacto { get; set; } = string.Empty;

        public string TelefonoSegundoContacto { get; set; } = string.Empty;

        public byte[] Logo { get; set; } = null;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}