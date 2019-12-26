using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaObjetos
{
    public class ObjDepartamentos
    {
        public string Accion { get; set; } = string.Empty;

        public int IdDepartamento { get; set; } = 0;

        public string Alias { get; set; } = string.Empty;
        
        public string Descripcion { get; set; } = string.Empty;
        
        public bool Estado { get; set; } = false;
        
        public string UsuarioCreacion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public string UsuarioModificacion { get; set; } = string.Empty;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}