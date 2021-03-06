﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISASEPBA.Models
{
    public class TipoLicencias
    {
        public string Accion { get; set; } = string.Empty;

        public int IdTipoLicencia { get; set; } = 0;

        [DisplayName("Alias")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Alias { get; set; } = string.Empty;

        [DisplayName("Estado")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public bool Estado { get; set; } = false;

        [DisplayName("Descripción")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Excede el máximo de caracteres permitidos")]
        [Required(ErrorMessage = "*Campo requerido.")]
        public string Descripcion { get; set; } = string.Empty;

        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string UsuarioModificacion { get; set; } = string.Empty;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}