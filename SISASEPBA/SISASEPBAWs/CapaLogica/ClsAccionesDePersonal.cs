using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SISASEPBA.Capa_Datos;

namespace SISASEPBAWs.CapaLogica
{
    public class ClsAccionesDePersonal
    {
        #region Constantes
        private const string SpConexion = "SP_Acciones_Personal";
        private static string _mensaje;
        #endregion 

        #region Variables
        private static SqlConnection _conexion;
        #endregion

        public static Response ProcesarAPContratacion(AccionDePersonal obj)
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
                    comando.Parameters.AddWithValue("@@IdAccionPersonal", obj.IdAccionPersonal);
                    comando.Parameters.AddWithValue("@@IdTipoAP", obj.IdTipoAP);
                    comando.Parameters.AddWithValue("@@IdEmpleado", obj.IdEmpleado);
                    comando.Parameters.AddWithValue("@@IdNacionalidad", obj.IdNacionalidad);
                    comando.Parameters.AddWithValue("@@IdDepartamento", obj.IdDepartamento);
                    comando.Parameters.AddWithValue("@@IdPuesto", obj.IdPuesto);
                    comando.Parameters.AddWithValue("@@IdNomina", obj.IdNomina);
                    comando.Parameters.AddWithValue("@@IdFormaPago", obj.IdFormaPago);
                    comando.Parameters.AddWithValue("@@IdRegimenVacacional", obj.IdRegimenVacacional);
                    comando.Parameters.AddWithValue("@@EstadoAP", obj.EstadoAP);
                    comando.Parameters.AddWithValue("@@UsuarioCreacion", obj.UsuarioCreacion);
                    comando.Parameters.AddWithValue("@@FechaCreacion", obj.FechaCreacion);
                    comando.Parameters.AddWithValue("@@UsuarioAprobacion", obj.UsuarioAprobacion);
                    comando.Parameters.AddWithValue("@@FechaAprobacion", obj.FechaAprobacion);
                    comando.Parameters.AddWithValue("@@UsuarioAplicacion", obj.UsuarioAplicacion);
                    comando.Parameters.AddWithValue("@@FechaAplicacion", obj.FechaAplicacion);
                    comando.Parameters.AddWithValue("@@UsuarioCancelacion", obj.UsuarioCanelacion);
                    comando.Parameters.AddWithValue("@@FechaCancelacion", obj.FechaCancelacion);
                    comando.Parameters.AddWithValue("@@UsuarioDenegacion", obj.UsuarioDenegacion);
                    comando.Parameters.AddWithValue("@@FechaDenegacion", obj.FechaDenegacion);
                    comando.Parameters.AddWithValue("@@DiasAP", obj.DiasAP);
                    comando.Parameters.AddWithValue("@@FechaRige", obj.FechaRige);
                    comando.Parameters.AddWithValue("@@FechaVence", obj.FechaVence);
                    comando.Parameters.AddWithValue("@@SaldoVacaciones", obj.SaldoVacaciones);
                    comando.Parameters.AddWithValue("@@AhorroAsociacion", obj.AhorroAsociacion);
                    comando.Parameters.AddWithValue("@@CodigoEmpleado", obj.CodigoEmpleado);
                    comando.Parameters.AddWithValue("@@EmpleadoPrimerNombre", obj.EmpleadoPrimerNombre);
                    comando.Parameters.AddWithValue("@@EmpleadoSegundoNombre", obj.EmpleadoSegundoNombre);
                    comando.Parameters.AddWithValue("@@EmpleadoPrimerApellido", obj.EmpleadoPrimerApellido);
                    comando.Parameters.AddWithValue("@@EmpleadoSegundoApellido", obj.EmpleadoSegundoApellido);
                    comando.Parameters.AddWithValue("@@TipoIdentificacion", obj.TipoIdentificacion);
                    comando.Parameters.AddWithValue("@@NumeroIdentificacion", obj.NumeroIdentificacion);
                    comando.Parameters.AddWithValue("@@TelefonoPrincipal", obj.TelefonoPrincipal);
                    comando.Parameters.AddWithValue("@@TelefonoSecundario", obj.TelefonoSecundario);
                    comando.Parameters.AddWithValue("@@TelefonoEmergencia", obj.TelefonoEmergencia);
                    comando.Parameters.AddWithValue("@@ContactoEmergencia", obj.ContactoEmergencia);
                    comando.Parameters.AddWithValue("@@FechaNacimiento", obj.FechaNacimiento);
                    comando.Parameters.AddWithValue("@@TipoSangre", obj.TipoSangre);
                    comando.Parameters.AddWithValue("@@DireccionDomicilio", obj.DireccionDomicilio);
                    comando.Parameters.AddWithValue("@@Sexo", obj.Sexo);
                    comando.Parameters.AddWithValue("@@EstadoCivil", obj.EstadoCivil);
                    comando.Parameters.AddWithValue("@@Estado", obj.Estado);
                    comando.Parameters.AddWithValue("@@SubEstado", obj.SubEstado);
                    comando.Parameters.AddWithValue("@@CorreoElectronico", obj.CorreoElectronico);
                    comando.Parameters.AddWithValue("@@ConyugeDependiente", obj.ConyugeDependiente);
                    comando.Parameters.AddWithValue("@@HijosDependientes", obj.HijosDependientes);
                    comando.Parameters.AddWithValue("@@NumeroAsegurado", obj.NumeroAsegurado);
                    comando.Parameters.AddWithValue("@@VacacionesPendientes", obj.VacacionesPendientes);
                    comando.Parameters.AddWithValue("@@UltimoCambioVacacional", obj.UltimoCambioVacacional);
                    comando.Parameters.AddWithValue("@@SalarioReferencia", obj.SalarioReferencia);
                    comando.Parameters.AddWithValue("@@Foto", obj.Foto);
                    comando.Parameters.AddWithValue("@@ObservacionesGenerales", obj.ObservacionesGenerales);
                    comando.Parameters.AddWithValue("@@ObservacionesAP", obj.ObservacionesAP);       
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

        public static DataSet ConsultarAPContratacion(AccionDePersonal obj)
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
                    comando.Parameters.AddWithValue("@@IdAccionPersonal", obj.IdAccionPersonal);
                    comando.Parameters.AddWithValue("@@IdTipoAP", obj.IdTipoAP);
                    comando.Parameters.AddWithValue("@@IdEmpleado", obj.IdEmpleado);
                    comando.Parameters.AddWithValue("@@IdNacionalidad", obj.IdNacionalidad);
                    comando.Parameters.AddWithValue("@@IdDepartamento", obj.IdDepartamento);
                    comando.Parameters.AddWithValue("@@IdPuesto", obj.IdPuesto);
                    comando.Parameters.AddWithValue("@@IdNomina", obj.IdNomina);
                    comando.Parameters.AddWithValue("@@IdFormaPago", obj.IdFormaPago);
                    comando.Parameters.AddWithValue("@@IdRegimenVacacional", obj.IdRegimenVacacional);
                    comando.Parameters.AddWithValue("@@EstadoAP", obj.EstadoAP);
                    comando.Parameters.AddWithValue("@@UsuarioCreacion", obj.UsuarioCreacion);
                    comando.Parameters.AddWithValue("@@FechaCreacion", obj.FechaCreacion);
                    comando.Parameters.AddWithValue("@@UsuarioAprobacion", obj.UsuarioAprobacion);
                    comando.Parameters.AddWithValue("@@FechaAprobacion", obj.FechaAprobacion);
                    comando.Parameters.AddWithValue("@@UsuarioAplicacion", obj.UsuarioAplicacion);
                    comando.Parameters.AddWithValue("@@FechaAplicacion", obj.FechaAplicacion);
                    comando.Parameters.AddWithValue("@@UsuarioCancelacion", obj.UsuarioCanelacion);
                    comando.Parameters.AddWithValue("@@FechaCancelacion", obj.FechaCancelacion);
                    comando.Parameters.AddWithValue("@@UsuarioDenegacion", obj.UsuarioDenegacion);
                    comando.Parameters.AddWithValue("@@FechaDenegacion", obj.FechaDenegacion);
                    comando.Parameters.AddWithValue("@@DiasAP", obj.DiasAP);
                    comando.Parameters.AddWithValue("@@FechaRige", obj.FechaRige);
                    comando.Parameters.AddWithValue("@@FechaVence", obj.FechaVence);
                    comando.Parameters.AddWithValue("@@SaldoVacaciones", obj.SaldoVacaciones);
                    comando.Parameters.AddWithValue("@@AhorroAsociacion", obj.AhorroAsociacion);
                    comando.Parameters.AddWithValue("@@CodigoEmpleado", obj.CodigoEmpleado);
                    comando.Parameters.AddWithValue("@@EmpleadoPrimerNombre", obj.EmpleadoPrimerNombre);
                    comando.Parameters.AddWithValue("@@EmpleadoSegundoNombre", obj.EmpleadoSegundoNombre);
                    comando.Parameters.AddWithValue("@@EmpleadoPrimerApellido", obj.EmpleadoPrimerApellido);
                    comando.Parameters.AddWithValue("@@EmpleadoSegundoApellido", obj.EmpleadoSegundoApellido);
                    comando.Parameters.AddWithValue("@@TipoIdentificacion", obj.TipoIdentificacion);
                    comando.Parameters.AddWithValue("@@NumeroIdentificacion", obj.NumeroIdentificacion);
                    comando.Parameters.AddWithValue("@@TelefonoPrincipal", obj.TelefonoPrincipal);
                    comando.Parameters.AddWithValue("@@TelefonoSecundario", obj.TelefonoSecundario);
                    comando.Parameters.AddWithValue("@@TelefonoEmergencia", obj.TelefonoEmergencia);
                    comando.Parameters.AddWithValue("@@ContactoEmergencia", obj.ContactoEmergencia);
                    comando.Parameters.AddWithValue("@@FechaNacimiento", obj.FechaNacimiento);
                    comando.Parameters.AddWithValue("@@TipoSangre", obj.TipoSangre);
                    comando.Parameters.AddWithValue("@@DireccionDomicilio", obj.DireccionDomicilio);
                    comando.Parameters.AddWithValue("@@Sexo", obj.Sexo);
                    comando.Parameters.AddWithValue("@@EstadoCivil", obj.EstadoCivil);
                    comando.Parameters.AddWithValue("@@Estado", obj.Estado);
                    comando.Parameters.AddWithValue("@@SubEstado", obj.SubEstado);
                    comando.Parameters.AddWithValue("@@CorreoElectronico", obj.CorreoElectronico);
                    comando.Parameters.AddWithValue("@@ConyugeDependiente", obj.ConyugeDependiente);
                    comando.Parameters.AddWithValue("@@HijosDependientes", obj.HijosDependientes);
                    comando.Parameters.AddWithValue("@@NumeroAsegurado", obj.NumeroAsegurado);
                    comando.Parameters.AddWithValue("@@VacacionesPendientes", obj.VacacionesPendientes);
                    comando.Parameters.AddWithValue("@@UltimoCambioVacacional", obj.UltimoCambioVacacional);
                    comando.Parameters.AddWithValue("@@SalarioReferencia", obj.SalarioReferencia);
                    comando.Parameters.AddWithValue("@@Foto", obj.Foto);
                    comando.Parameters.AddWithValue("@@ObservacionesGenerales", obj.ObservacionesGenerales);
                    comando.Parameters.AddWithValue("@@ObservacionesAP", obj.ObservacionesAP);
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