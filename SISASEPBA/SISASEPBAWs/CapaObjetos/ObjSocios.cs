using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjSocios
    {
        public string Accion { get; set; } = string.Empty;

        public int IdSocio { get; set; } = 0;

        public int NumeroIdentificacion { get; set; } = 0;

        public string PrimerNombreSocio { get; set; } = string.Empty;

        public string SegundoNombreSocio { get; set; } = string.Empty;

        public string PrimerApellidoSocio { get; set; } = string.Empty;

        public string SegundoApellidoSocio { get; set; } = string.Empty;

        public string Empresa { get; set; } = string.Empty;

        public DateTime FechaIngresoAsociacion { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = false;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}