﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SISASEPBA.Models
{
    public class APAscenso
    {
        public string Accion { get; set; } = string.Empty;

        public int IdAccionPersonal { get; set; } = 0;

        public int IdTipoAP { get; set; } = 0;

        public int IdEmpleado { get; set; } = 0;

        [DisplayName("Departamento:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdDepartamento { get; set; } = string.Empty;

        [DisplayName("Puesto:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdPuesto { get; set; } = string.Empty;

        [DisplayName("Nomina:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string IdNomina { get; set; } = string.Empty;

        [DisplayName("Salario de referencia:")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public decimal SalarioReferencia { get; set; } = 0;

        [StringLength(150, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        [DisplayName("Observaciones de Acción de Personal:")]
        public string ObservacionesAP { get; set; } = string.Empty;

        [DisplayName("Fecha en la que rige")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public DateTime FechaRige { get; set; } = DateTime.Now;

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