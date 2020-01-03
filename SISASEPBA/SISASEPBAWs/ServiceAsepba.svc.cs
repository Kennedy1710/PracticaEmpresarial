using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SISASEPBAWs.CapaLogica;

namespace SISASEPBAWs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceAsepba : IServiceAsepba
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}



        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response Login(string username, string password)
        {
            try
            {
                return ClsSeguridad.Login(username, password);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarUsuarios(Usuario obj)
        {
            try
            {
                return ClsUsuarios.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarUsuarios(Usuario obj)
        {
            try
            {
                return ClsUsuarios.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarDepartamentos(Departamento obj)
        {
            try
            {
                return ClsDepartamentos.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarDepartamentos(Departamento obj)
        {
            try
            {
                return ClsDepartamentos.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarPuestos(Puesto obj)
        {
            try
            {
                return ClsPuestos.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarPuestos(Puesto obj)
        {
            try
            {
                return ClsPuestos.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarTipoLicencia(TipoLicencia obj)
        {
            try
            {
                return ClsEmpleadoLicencia.ConsultarTipoLicencia(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarEmpleadoLicencia(EmpleadoLicencia obj)
        {
            try
            {
                return ClsEmpleadoLicencia.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarEmpleadoLicencia(EmpleadoLicencia obj)
        {
            try
            {
                return ClsEmpleadoLicencia.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarNacionalidad(Nacionalidad obj)
        {
            try
            {
                return ClsEmpleado.ConsultarNacionalidad(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarNomina(Nomina obj)
        {
            try
            {
                return ClsNominas.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarNomina(Nomina obj)
        {
            try
            {
                return ClsNominas.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response ProcesarControlVacacional(ControlVacacional obj)
        {
            try
            {
                return ClsControlVacacional.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarControlVacacional(ControlVacacional obj)
        {
            try
            {
                return ClsControlVacacional.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarFormaPago(FormaPago obj)
        {
            try
            {
                return ClsEmpleado.ConsultarFormaPago(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarCapacitacion(Capacitacion obj)
        {
            try
            {
                return ClsCapacitaciones.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarCapacitacion(Capacitacion obj)
        {
            try
            {
                return ClsCapacitaciones.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarTipoCapacitacion(TipoCapacitacion obj)
        {
            try
            {
                return ClsCapacitaciones.ConsultarTipoCapacitacion(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarEmpleado(Empleado obj)
        {
            try
            {
                return ClsEmpleado.Procesar(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarEmpleado(Empleado obj)
        {
            try
            {
                return ClsEmpleado.Consultar(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarAccionDePersonal(AccionDePersonal obj)
        {
            try
            {
                return ClsAccionesDePersonal.ProcesarAPContratacion(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarAccionDePersonal(AccionDePersonal obj)
        {
            try
            {
                return ClsAccionesDePersonal.ConsultarAPContratacion(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarNominasHistorico(NominasHistorico obj)
        {
            try
            {
                return ClsNominasHistorico.ProcesarNominaHistorico(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarNominasHistorico(NominasHistorico obj)
        {
            try
            {
                return ClsNominasHistorico.ConsultarNominaHistorico(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarEmpleadoConceptoNomina(EmpleadoConceptoNomina obj)
        {
            try
            {
                return ClsEmpleadoConceptoNomina.ProcesarEmpleadoConceptoNomina(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarEmpleadoConceptoNomina(EmpleadoConceptoNomina obj)
        {
            try
            {
                return ClsEmpleadoConceptoNomina.ConsultarEmpleadoConceptoNomina(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarEmpleadoConcepto(EmpleadoConcepto obj)
        {
            try
            {
                return ClsEmpleadoConcepto.ProcesarEmpleadoConcepto(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarEmpleadoConcepto(EmpleadoConcepto obj)
        {
            try
            {
                return ClsEmpleadoConcepto.ConsultarEmpleadoConcepto(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarConcepto(Conceptos obj)
        {
            try
            {
                return ClsConceptos.ProcesarConcepto(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarConcepto(Conceptos obj)
        {
            try
            {
                return ClsConceptos.ConsultarConcepto(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarConceptoFormula(ConceptoFormula obj)
        {
            try
            {
                return ClsConceptoFormula.ProcesarConceptoFormula(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarConceptoFormula(ConceptoFormula obj)
        {
            try
            {
                return ClsConceptoFormula.ConsultarConceptoFormula(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarConceptoLiquidacion(ConceptoLiquidacion obj)
        {
            try
            {
                return ClsConceptoLiquidacion.ProcesarConceptoLiquidacion(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarConceptoLiquidacion(ConceptoLiquidacion obj)
        {
            try
            {
                return ClsConceptoLiquidacion.ConsultarConceptoLiquidacion(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarEmpleadoConceptoLiquidacion(EmpleadoConceptoLiquidacion obj)
        {
            try
            {
                return ClsEmpleadoConceptoLiquidacion.ProcesarEmpleadoConceptoLiquidacion(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarEmpleadoConceptoLiquidacion(EmpleadoConceptoLiquidacion obj)
        {
            try
            {
                return ClsEmpleadoConceptoLiquidacion.ConsultarEmpleadoConceptoLiquidacion(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public Response ProcesarDocumentos(Documentos obj)
        {
            try
            {
                return ClsDocumentos.ProcesarDocumentos(obj);
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarDocumentos(Documentos obj)
        {
            try
            {
                return ClsDocumentos.ConsultarDocumentos(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public DataSet ConsultarTipoDocumento(TipoDocumento obj)
        {
            try
            {
                return ClsTipoDocumento.ConsultarTipoDocumento(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
