using System;
using System.Data;
using System.Data.SqlClient;
using SISASEPBA.Capa_Datos;

namespace SISASEPBAWs.CapaLogica
{
    public class ClsUsuarios
    {
        #region Constantes
        private const string SpConexion = "SP_Usuarios";
        private static string _mensaje;
        #endregion

        #region Variables
        private static SqlConnection _conexion;
        #endregion


        public static Response Procesar(Usuario obj)
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

                    comando.Parameters.AddWithValue("@@Accion", obj.Accion);
                    comando.Parameters.AddWithValue("@@Usuario", obj.CodUsuario);
                    comando.Parameters.AddWithValue("@@Nombre", obj.Nombre);
                    comando.Parameters.AddWithValue("@@EsEmpleado", obj.EsEmpleado);
                    comando.Parameters.AddWithValue("@@Empresa", obj.Empresa);
                    comando.Parameters.AddWithValue("@@CodigoEmpleado", obj.CodEmpleado);
                    comando.Parameters.AddWithValue("@@Contrasena", obj.Contrasena);
                    comando.Parameters.AddWithValue("@@ContrasenaVence", obj.ContrasenaVence);
                    comando.Parameters.AddWithValue("@@CambioProximo", obj.CambioProximoInicio);
                    comando.Parameters.AddWithValue("@@DiasVencimiento", obj.DiasVencimiento);
                    comando.Parameters.AddWithValue("@@MaximoIntentos", obj.MaximoIntentos);
                    comando.Parameters.AddWithValue("@@Correo", obj.Correo);
                    comando.Parameters.AddWithValue("@@Estado", obj.Estado);
                    comando.Parameters.AddWithValue("@@UsuarioSistema", obj.UsuarioSesion);


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
                        IsSuccess = true,
                        Result = resultado.Rows[0][0]
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

        public static DataSet Consultar(Usuario obj)
        {
            try
            {
                var comando = new SqlCommand();
                _conexion = AccesoDatos.Validar_Conexion("SisAsepba", ref _mensaje);
                if (_conexion == null)
                {
                    _mensaje = "Error al encontrar la conexion proporcionada";
                    return null;
                }
                else
                {
                    AccesoDatos.Conectar(_conexion, ref _mensaje);

                    comando.Connection = _conexion;
                    comando.CommandText = SpConexion;
                    comando.Parameters.AddWithValue("@@Accion", obj.Accion);
                    comando.Parameters.AddWithValue("@@Usuario", obj.CodUsuario);
                    comando.Parameters.AddWithValue("@@Nombre", obj.Nombre);
                    comando.Parameters.AddWithValue("@@EsEmpleado", obj.EsEmpleado);
                    comando.Parameters.AddWithValue("@@Empresa", obj.Empresa);
                    comando.Parameters.AddWithValue("@@CodigoEmpleado", obj.CodEmpleado);
                    comando.Parameters.AddWithValue("@@Contrasena", obj.Contrasena);
                    comando.Parameters.AddWithValue("@@ContrasenaVence", obj.ContrasenaVence);
                    comando.Parameters.AddWithValue("@@CambioProximo", obj.CambioProximoInicio);
                    comando.Parameters.AddWithValue("@@DiasVencimiento", obj.DiasVencimiento);
                    comando.Parameters.AddWithValue("@@MaximoIntentos", obj.MaximoIntentos);
                    comando.Parameters.AddWithValue("@@Correo", obj.Correo);
                    comando.Parameters.AddWithValue("@@Estado", obj.EsEmpleado);
                    comando.Parameters.AddWithValue("@@UsuarioSistema", obj.UsuarioSesion);

                    var resultado = AccesoDatos.LlenarDataTable(comando, ref _mensaje);
                    var ds = new DataSet();
                    ds.Tables.Add(resultado.Copy());
                    return ds;
                }

            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
                return null;
            }
            finally
            {
                AccesoDatos.Desconectar(_conexion, ref _mensaje);
            }
        }

    }
}