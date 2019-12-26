using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SISASEPBA.Capa_Datos
{
    public static class AccesoDatos
    {
        #region Validar_Conexion

        public static SqlConnection Validar_Conexion(string nombreConexion, ref string mensajeError)
        {
            try
            {
                var cadenaConexion = ConfigurationManager.ConnectionStrings[nombreConexion].ToString();
                var conexion = new SqlConnection(cadenaConexion);
                mensajeError = string.Empty;
                return conexion;
            }
            catch (NullReferenceException ex)
            {
                mensajeError = ex.Message;
                return null;

            }
            catch (SqlException ex)
            {
                mensajeError = "Ha ocurrido un error al encontrar la conexion " + nombreConexion + "Informacion adicional: " + ex.Message;
                return null;
            }

        }
        public static void Conectar(SqlConnection conexion, ref string mensajeError)
        {
            try
            {
                conexion.Open();
            }
            catch (SqlException ex)
            {
                mensajeError = "Ha ocurrido un error al conectarse al servidor de datos informacion adicional: " + ex.Message;
            }
        }

        public static void Desconectar(SqlConnection conexion, ref string mensajeError)
        {
            try
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                mensajeError = "Ha ocurrido un error al desconectar informacion adicional: " + ex.Message;
            }
        }

        public static DataTable LlenarDataTable(SqlCommand comando, ref string mensajeError)
        {
            var dt = new DataTable();
            var ds = new DataSet();
            try
            {
                var da = new SqlDataAdapter(comando) { SelectCommand = { CommandType = CommandType.StoredProcedure } };
                da.Fill(ds);
                if (ds.Tables.Count == 0)
                {
                    mensajeError = "Ha ocurido un error en la consulta";
                }
                else
                {
                    dt = ds.Tables[0];
                    mensajeError = string.Empty;
                }
                return dt;
            }
            catch (SqlException ex)
            {
                mensajeError = string.Empty;
                dt.Columns.Add("RESULTADO", typeof(string));
                dt.Columns.Add("MENSAJE", typeof(string));
                dt.Rows.Add("False", "WS: " + ex.Message);
                return dt;
            }

        }

        public static DataTable EjecutarProcedimientoOutput(SqlCommand comando, ref string mensajeError)
        {
            var temp = new DataTable();
            temp.Columns.Add("RESULTADO", typeof(string));
            temp.Columns.Add("MENSAJE", typeof(string));
            try

            {
                comando.CommandType = CommandType.StoredProcedure;
                var resultado = comando.ExecuteNonQuery();

                var estado = comando.Parameters["@@RESULTADO"].Value.ToString();
                var mensaje = comando.Parameters["@@MENSAJE"].Value.ToString();
                temp.Rows.Add(estado, mensaje);

                if (temp.Rows.Count == 0)
                {
                    temp.Rows.Add("False", "WS: " + "La consulta no retorno ningun resultado");
                    return temp;
                }
                else
                {
                    mensajeError = string.Empty;
                    return temp;
                }
            }
            catch (SqlException ex)
            {
                temp.Rows.Add("False", "WS: " + ex.Message);
                return temp;
            }
        }
        #endregion
    }
}