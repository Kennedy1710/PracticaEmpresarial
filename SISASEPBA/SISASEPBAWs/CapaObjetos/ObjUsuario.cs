namespace SISASEPBA.Capa_Objetos
{
    public class ObjUsuario
    {
        public string Opcion { get; set; } = string.Empty;
        public int IdUsuario { get; set; } = 0;
        public string CodUsuario { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public bool EsEmpleado { get; set; } = false;
        public string CodEmpleado { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public bool ContrasenaVence { get; set; } = false;
        public bool CambioProximoInicio { get; set; } = false;
        public string TipoInicioSesion { get; set; } = string.Empty;
        public int DiasVencimiento { get; set; } = 0;
        public int MaximoIntentos { get; set; } = 0;
        public string Correo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string UsuarioCreacion { get; set; } = string.Empty;

    }
}