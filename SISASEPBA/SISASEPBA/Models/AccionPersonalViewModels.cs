using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISASEPBA.Models
{
    public class AccionPersonalViewModels
    {
        public List<Models.AccionPersonal> AccionPersonals { get; set; }
        public List<Models.Empleado> Empleados { get; set; }
        public List<Models.TipoAccion> TipoAccions { get; set; }
    }
}