using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjControlVacacional
    {
        public string Accion { get; set; } = string.Empty;

        public int IdRegimenVacacional { get; set; } = 0;

        public string Alias { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int IdTipoAP { get; set; } = 0;

        public bool Estado { get; set; } = false;

        public int DiasAcuMes { get; set; } = 0;

        public int DiasRestados { get; set; } = 0;

        public bool IncluirSabados { get; set; } = false;

        public bool IncluirDomingos { get; set; } = false;

        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}