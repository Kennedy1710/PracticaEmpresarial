using SISASEPBA.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SISASEPBAWs.CapaLogica
{
    public class ClsDocumentos
    {

        #region
        private const string SpConexion = "SP_Documentos";
        private static string _mensaje;
        #endregion

        #region Variables
        private static SqlConnection _conexion;
        #endregion

        public static Response ProcesarDocumentos(Documentos obj)
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
                    comando.Parameters.AddWithValue("@@IdDocumento", obj.IdDocumento);
                    comando.Parameters.AddWithValue("@@IdTipoDocumento", obj.IdTipoDocumento);
                    comando.Parameters.AddWithValue("@@TituloDocumento", obj.TituloDocumento);
                    comando.Parameters.AddWithValue("@@Descripcion", obj.Descripcion);
                    comando.Parameters.AddWithValue("@@FechaRige", obj.FechaRige);
                    comando.Parameters.AddWithValue("@@FechaVence", obj.FechaVence);
                    comando.Parameters.AddWithValue("@@Estado", obj.Estado);
                    comando.Parameters.AddWithValue("@@DocumentoAdjunto ", obj.DocumentoAdjunto);
                    comando.Parameters.AddWithValue("@@IdRenovacion", obj.IdRenovacion);
                    comando.Parameters.AddWithValue("@@UsuarioCreacion", obj.UsuarioCreacion);
                    comando.Parameters.AddWithValue("@@FechaCreacion", obj.FechaCreacion);
                    comando.Parameters.AddWithValue("@@UsuarioModificacion", obj.UsuarioModificacion);
                    comando.Parameters.AddWithValue("@@FechaModificacion", obj.FechaModificacion);



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

        public static DataSet ConsultarDocumentos(Documentos obj)
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
                    comando.Parameters.AddWithValue("@@IdDocumento", obj.IdDocumento);
                    comando.Parameters.AddWithValue("@@IdTipoDocumento", obj.IdTipoDocumento);
                    comando.Parameters.AddWithValue("@@TituloDocumento", obj.TituloDocumento);
                    comando.Parameters.AddWithValue("@@Descripcion", obj.Descripcion);
                    comando.Parameters.AddWithValue("@@FechaRige", obj.FechaRige);
                    comando.Parameters.AddWithValue("@@FechaVence", obj.FechaVence);
                    comando.Parameters.AddWithValue("@@Estado", obj.Estado);
                    comando.Parameters.AddWithValue("@@DocumentoAdjunto ", obj.DocumentoAdjunto);
                    comando.Parameters.AddWithValue("@@IdRenovacion", obj.IdRenovacion);
                    comando.Parameters.AddWithValue("@@UsuarioCreacion", obj.UsuarioCreacion);
                    comando.Parameters.AddWithValue("@@FechaCreacion", obj.FechaCreacion);
                    comando.Parameters.AddWithValue("@@UsuarioModificacion", obj.UsuarioModificacion);
                    comando.Parameters.AddWithValue("@@FechaModificacion", obj.FechaModificacion);

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