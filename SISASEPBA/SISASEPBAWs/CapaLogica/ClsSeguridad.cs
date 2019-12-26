using System;
using System.Data.SqlClient;
using SISASEPBA.Capa_Datos;

namespace SISASEPBAWs.CapaLogica
{
    public class ClsSeguridad
    {
        #region Constantes
        private const string SpConexion = "SP_InicioSesion";
        private static string _mensaje;
        #endregion

        #region Variables
        private static SqlConnection _conexion;
        #endregion
        public static string Encriptar(string _cadenaAencriptar)
        {
            var encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            for (var a = 0; a < encryted.Length; a++)
            {
                if (encryted[a] != 0)
                {
                    encryted[a] = Convert.ToByte((encryted[a] * 2));
                }
            }
            var result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(string _cadenaAdesencriptar)
        {
            var decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            for (var a = 0; a < decryted.Length; a++)
            {
                if (decryted[a] != 0)
                {
                    decryted[a] = Convert.ToByte((decryted[a] / 2));
                }
            }
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            var result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static Response Login(string user, string pass)
        {
            try
            {
                var comando = new SqlCommand();
                _conexion = AccesoDatos.Validar_Conexion("SisAsepba", ref _mensaje);
                if (_conexion == null)
                {
                    // mensaje = "Error al encontrar la conexion proporcionada";
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Error al encontrar la conexion proporcionada"
                    };
                }
                else
                {
                    AccesoDatos.Conectar(_conexion, ref _mensaje);

                    comando.Connection = _conexion;
                    comando.CommandText = SpConexion;

                    comando.Parameters.AddWithValue("@@Usuario", user);
                    comando.Parameters.AddWithValue("@@Contrasena", pass);

                    var resultado = AccesoDatos.LlenarDataTable(comando, ref _mensaje);

                    //return string.IsNullOrEmpty(mensaje) ? Convert.ToBoolean(resultado.Rows[0][0] ) : false;
                    if (resultado == null || resultado.Rows.Count < 0)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = "Error a la hora de realizar la consulta"
                        };
                    }

                    return new Response
                    {
                        IsSuccess = Convert.ToBoolean(resultado.Rows[0][0]),
                        Result = resultado.Rows[0][1]
                    };
                }
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
                return new Response
                {
                    IsSuccess = false,
                    Message = "Error a la hora de realizar la consulta, detalle del error: " + ex.Message
                };
            }
            finally
            {
                AccesoDatos.Desconectar(_conexion, ref _mensaje);
            }
        }

    }
}