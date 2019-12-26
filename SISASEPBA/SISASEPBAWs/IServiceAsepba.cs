using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SISASEPBAWs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [XmlSerializerFormat]
    [ServiceContract]
    public interface IServiceAsepba
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarUsuarios(Usuario obj);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarUsuarios(Usuario obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response Login(string usr, string pass);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarDepartamentos(Departamento obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarDepartamentos(Departamento obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarPuestos(Puesto obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarPuestos(Puesto obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarTipoLicencia(TipoLicencia obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarEmpleadoLicencia(EmpleadoLicencia obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarEmpleadoLicencia(EmpleadoLicencia obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarNacionalidad(Nacionalidad obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarNomina(Nomina obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarNomina(Nomina obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarControlVacacional(ControlVacacional obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarControlVacacional(ControlVacacional obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarFormaPago(FormaPago obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarCapacitacion(Capacitacion obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarCapacitacion(Capacitacion obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarEmpleado(Empleado obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarEmpleado(Empleado obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarAccionDePersonal(AccionDePersonal obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarAccionDePersonal(AccionDePersonal obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarNominasHistorico(NominasHistorico obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarNominasHistorico(NominasHistorico obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarEmpleadoConceptoNomina(EmpleadoConceptoNomina obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarEmpleadoConceptoNomina(EmpleadoConceptoNomina obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarEmpleadoConcepto(EmpleadoConcepto obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarEmpleadoConcepto(EmpleadoConcepto obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarConcepto(Conceptos obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarConcepto(Conceptos obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarConceptoFormula(ConceptoFormula obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarConceptoFormula(ConceptoFormula obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarConceptoLiquidacion(ConceptoLiquidacion obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarConceptoLiquidacion(ConceptoLiquidacion obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Response ProcesarEmpleadoConceptoLiquidacion(EmpleadoConceptoLiquidacion obj);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        DataSet ConsultarEmpleadoConceptoLiquidacion(EmpleadoConceptoLiquidacion obj);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        //bool boolValue = true;
        //string stringValue = "Hello ";

        //[DataMember]
        //public bool BoolValue
        //{
        //    get { return boolValue; }
        //    set { boolValue = value; }
        //}

        //[DataMember]
        //public string StringValue
        //{
        //    get { return stringValue; }
        //    set { stringValue = value; }
        //}


    }
    [DataContract]
    public class Response
    {
        [DataMember] public bool IsSuccess { get; set; }
        [DataMember] public bool RequiereCambiarContraseña { get; set; }
        [DataMember] public string Message { get; set; }
        [DataMember] public object Result { get; set; }
        [DataMember] public int Intentos { get; set; }
    }

    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public string CodUsuario { get; set; } = string.Empty;
        [DataMember]
        public string Nombre { get; set; } = string.Empty;
        [DataMember]
        public string Empresa { get; set; } = string.Empty;
        [DataMember]
        public bool EsEmpleado { get; set; } = false;
        [DataMember]
        public string CodEmpleado { get; set; } = string.Empty;
        [DataMember]
        public string Contrasena { get; set; } = string.Empty;
        [DataMember]
        public bool ContrasenaVence { get; set; } = false;
        [DataMember]
        public bool CambioProximoInicio { get; set; } = false;
        [DataMember]
        public int DiasVencimiento { get; set; } = 0;
        [DataMember]
        public int MaximoIntentos { get; set; } = 0;
        [DataMember]
        public string Correo { get; set; } = string.Empty;
        [DataMember]
        public string Estado { get; set; } = string.Empty;
        [DataMember]
        public string UsuarioSesion { get; set; } = string.Empty;

    }

    [DataContract]
    public class Departamento
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdDepartamento { get; set; } = 0;
        [DataMember]

        public string Alias { get; set; } = string.Empty;
        [DataMember]
        public string Descripcion { get; set; } = string.Empty;
        [DataMember]
        public bool Estado { get; set; } = false;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }

    [DataContract]
    public class Puesto
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdPuesto { get; set; } = 0;
        public int IdDepartamento { get; set; } = 0;

        public string AliasDepartamento { get; set; } = string.Empty;
        [DataMember]
        public string Alias { get; set; } = string.Empty;
        [DataMember]
        public string Descripcion { get; set; } = string.Empty;
        [DataMember]
        public bool Estado { get; set; } = false;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }

    [DataContract]
    public class TipoLicencia
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdTipoLicencia { get; set; } = 0;
        [DataMember]
        public string Alias { get; set; } = string.Empty;
        [DataMember]
        public bool Estado { get; set; } = false;
        [DataMember]
        public string Descripcion { get; set; } = string.Empty;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }

    [DataContract]
    public class EmpleadoLicencia
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdEmpleadoLicencia { get; set; } = 0;
        public int IdEmpleado { get; set; } = 0;
        public int IdTipoLicencia { get; set; } = 0;
        [DataMember]
        public DateTime FechaVencimiento { get; set; } = DateTime.Now;
        [DataMember]
        public bool Estado { get; set; } = false;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class Nacionalidad
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdNacionalidad { get; set; } = 0;
        [DataMember]
        public string Alias { get; set; } = string.Empty;
        [DataMember]
        public string Descripcion { get; set; } = string.Empty;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class Nomina
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdNomina { get; set; } = 0;
        [DataMember]
        public string Alias { get; set; } = string.Empty;
        [DataMember]
        public string Descripcion { get; set; } = string.Empty;
        [DataMember]
        public string TipoNomina { get; set; } = string.Empty;
        [DataMember]
        public int Consecutivo { get; set; } = 0;
        [DataMember]
        public string Estado { get; set; } = string.Empty;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class ControlVacacional
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdRegimenVacacional { get; set; } = 0;
        [DataMember]
        public string Alias { get; set; } = string.Empty;
        [DataMember]
        public string Descripcion { get; set; } = string.Empty;
        [DataMember]
        public int IdTipoAP { get; set; } = 0;
        [DataMember]
        public bool Estado { get; set; } = false;
        [DataMember]
        public int DiasAcuMes { get; set; } = 0;
        [DataMember]
        public int DiasRestados { get; set; } = 0;
        [DataMember]
        public bool IncluirSabados { get; set; } = false;
        [DataMember]
        public bool IncluirDomingos { get; set; } = false;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class FormaPago
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdFormaPago { get; set; } = 0;
        [DataMember]
        public string Alias { get; set; } = string.Empty;
        [DataMember]
        public string Estado { get; set; } = string.Empty;
        [DataMember]
        public string Descripcion { get; set; } = string.Empty;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class Capacitacion
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        
        [DataMember]
        public int IdRegistro { get; set; } = 0;

        [DataMember]
        public int IdTipoCapacitacion { get; set; } = 0;

        [DataMember]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        
        [DataMember]
        public DateTime FechaInicio { get; set; } = DateTime.Now;

        [DataMember]
        public DateTime FechaFinalizacion { get; set; } = DateTime.Now;

        [DataMember]
        public int CantidadHoras { get; set; } = 0;

        [DataMember]
        public string NombreCapacitacion { get; set; } = string.Empty;

        [DataMember]
        public string Descripcion { get; set; } =string.Empty;

        [DataMember]
        public string NombreDelCapacitador { get; set; } = string.Empty;

        [DataMember]
        public string EmpresaCapacitadora { get; set; } = string.Empty;

        [DataMember]
        public string Formato { get; set; } = string.Empty;

        [DataMember]
        public string CargoPagoCapacitacion { get; set; } = string.Empty;

        [DataMember]
        public string Estado { get; set; } = string.Empty;

        [DataMember]
        public string DocumentoAdjunto { get; set; } = string.Empty;

        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }

    [DataContract]
    public class Empleado
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdEmpleado { get; set; } = 0;
        [DataMember]
        public int IdNacionalidad { get; set; } = 0;
        [DataMember]
        public int IdDepartamento { get; set; } = 0;
        [DataMember]
        public int IdPuesto { get; set; } = 0;
        [DataMember]
        public int IdNomina { get; set; } = 0;
        [DataMember]
        public int IdFormaPago { get; set; } = 0;
        [DataMember]
        public int IdRegimenVacacional { get; set; } = 0;
        [DataMember]
        public string CodigoEmpleado { get; set; } = string.Empty;
        [DataMember]
        public string PrimerNombre { get; set; } = string.Empty;
        [DataMember]
        public string SegundoNombre { get; set; } = string.Empty;
        [DataMember]
        public string PrimerApellido { get; set; } = string.Empty;
        [DataMember]
        public string SegundoApellido { get; set; } = string.Empty;
        [DataMember]
        public string TipoIdentificacion { get; set; } = string.Empty;
        [DataMember]
        public int NumeroIdentificacion { get; set; } = 0;
        [DataMember]
        public decimal AhorroAsociacion { get; set; } = 0;
        [DataMember]
        public string TelefonoPrincipal { get; set; } = string.Empty;
        [DataMember]
        public string TelefonoSecundario { get; set; } = string.Empty;
        [DataMember]
        public string TelefonoEmergencia { get; set; } = string.Empty;
        [DataMember]
        public string ContactoEmergencia { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime FechaSalida { get; set; } = DateTime.Now;
        [DataMember]
        public string TipoDeSangre { get; set; } = string.Empty;
        [DataMember]
        public string DireccionDomicilio { get; set; } = string.Empty;
        [DataMember]
        public string Sexo { get; set; } = string.Empty;
        [DataMember]
        public string EstadoCivil { get; set; } = string.Empty;
        [DataMember]
        public string Estado { get; set; } = string.Empty;
        [DataMember]
        public string SubEstado { get; set; } = string.Empty;
        [DataMember]
        public string CorreoElectronico { get; set; } = string.Empty;
        [DataMember]
        public bool ConyugeDependiente { get; set; } = false;
        [DataMember]
        public int HijosDependientes { get; set; } = 0;
        [DataMember]
        public string NumeroAsegurado { get; set; } = string.Empty;
        [DataMember]
        public int VacacionesPendientes { get; set; } = 0;
        [DataMember]
        public DateTime UltimoCambioVac { get; set; } = DateTime.Now;
        [DataMember]
        public decimal SalarioReferencia { get; set; } = 0;
        [DataMember]
        public byte[] Foto { get; set; } = null;
        [DataMember]
        public string ObservacionesGenerales { get; set; } = string.Empty;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }


    [DataContract]
    public class AccionDePersonal
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;

        [DataMember]
        public int IdAccionPersonal { get; set; } = 0;

        [DataMember]
        public int IdTipoAP { get; set; } = 0;

        [DataMember]
        public int IdEmpleado { get; set; } = 0;

        [DataMember]
        public int IdNacionalidad { get; set; } = 0;

        [DataMember]
        public int IdDepartamento { get; set; } = 0;

        [DataMember]
        public int IdPuesto { get; set; } = 0;

        [DataMember]
        public int IdNomina { get; set; } = 0;

        [DataMember]
        public int IdFormaPago { get; set; } = 0;

        [DataMember]
        public int IdRegimenVacacional { get; set; } = 0;

        [DataMember]
        public string EstadoAP { get; set; } = string.Empty;

        [DataMember]
        public string UsuarioAprobacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaAprobacion { get; set; } = DateTime.Now;

        [DataMember]
        public string UsuarioAplicacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaAplicacion { get; set; } = DateTime.Now;

        [DataMember]
        public string UsuarioCanelacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaCancelacion { get; set; } = DateTime.Now;

        [DataMember]
        public string UsuarioDenegacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaDenegacion { get; set; } = DateTime.Now;

        [DataMember]
        public int DiasAP { get; set; } = 0;

        [DataMember]
        public DateTime FechaRige { get; set; } = DateTime.Now;

        [DataMember]
        public DateTime FechaVence { get; set; } = DateTime.Now;

        [DataMember]
        public int SaldoVacaciones { get; set; } = 0;

        [DataMember]
        public decimal AhorroAsociacion { get; set; } = 0;

        [DataMember]
        public string CodigoEmpleado { get; set; } = string.Empty;

        [DataMember]
        public string EmpleadoPrimerNombre { get; set; } = string.Empty;

        [DataMember]
        public string EmpleadoSegundoNombre { get; set; } = string.Empty;

        [DataMember]
        public string EmpleadoPrimerApellido { get; set; } = string.Empty;

        [DataMember]
        public string EmpleadoSegundoApellido { get; set; } = string.Empty;

        [DataMember]
        public string TipoIdentificacion { get; set; } = string.Empty;

        [DataMember]
        public int NumeroIdentificacion { get; set; } = 0;

        [DataMember]
        public string TelefonoPrincipal { get; set; } = string.Empty;

        [DataMember]
        public string TelefonoSecundario { get; set; } = string.Empty;

        [DataMember]
        public string TelefonoEmergencia { get; set; } = string.Empty;

        [DataMember]
        public string ContactoEmergencia { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        [DataMember]
        public string TipoSangre { get; set; } = string.Empty;

        [DataMember]
        public string DireccionDomicilio { get; set; } = string.Empty;

        [DataMember]
        public string Sexo { get; set; } = string.Empty;

        [DataMember]
        public string EstadoCivil { get; set; } = string.Empty;

        [DataMember]
        public string Estado { get; set; } = string.Empty;

        [DataMember]
        public string SubEstado { get; set; } = string.Empty;

        [DataMember]
        public string CorreoElectronico { get; set; } = string.Empty;

        [DataMember]
        public bool ConyugeDependiente { get; set; } = false;

        [DataMember]
        public int HijosDependientes { get; set; } = 0;

        [DataMember]
        public string NumeroAsegurado { get; set; } = string.Empty;

        [DataMember]
        public int VacacionesPendientes { get; set; } = 0;

        [DataMember]
        public DateTime UltimoCambioVacacional { get; set; } = DateTime.Now;

        [DataMember]
        public decimal SalarioReferencia { get; set; } = 0;

        [DataMember]
        public byte[] Foto { get; set; } = null;

        [DataMember]
        public string ObservacionesGenerales { get; set; } = string.Empty;

        [DataMember]
        public string ObservacionesAP { get; set; } = string.Empty;

        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class NominasHistorico
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdNomina { get; set; } = 0;
        [DataMember]
        public int Consecutivo { get; set; } = 0;
        [DataMember]
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime FechaFin { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime Periodo { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime FechaPago { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime FechaCalculo { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioAprobacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaAprobacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioAplicacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaAplicacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class EmpleadoConceptoNomina
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdEmpleado { get; set; } = 0;
        [DataMember]
        public int IdConcepto { get; set; } = 0;
        [DataMember]
        public int IdNomina { get; set; } = 0;
        [DataMember]
        public int IdConceptoLiquidacion { get; set; } = 0;
        [DataMember]
        public int ConsecutivoNomina { get; set; } = 0;
        [DataMember]
        public int Cantidad { get; set; } = 0;
        [DataMember]
        public int Monto { get; set; } = 0;
        [DataMember]
        public int Total { get; set; } = 0;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class EmpleadoConcepto
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;

        [DataMember]
        public int IdConcepto { get; set; } = 0;

        [DataMember]
        public int IdEmpleado { get; set; } = 0;

        [DataMember]
        public int NumeroCuotas { get; set; } = 0;

        [DataMember]
        public int CuotasAplicadas { get; set; } = 0;

        [DataMember]
        public int SaldoInicial { get; set; } = 0;

        [DataMember]
        public int Saldo { get; set; } = 0;

        [DataMember]
        public int Acumulado { get; set; } = 0;

        [DataMember]
        public DateTime FechaUltimaAplicacion { get; set; } = DateTime.Now;

        [DataMember]
        public DateTime FechaProximaAplicacion { get; set; } = DateTime.Now;

        [DataMember]
        public DateTime FechaVencimiento { get; set; } = DateTime.Now;

        [DataMember]
        public int Cantidad { get; set; } = 0;

        [DataMember]
        public int Monto { get; set; } = 0;

        [DataMember]
        public string Comentarios { get; set; } = string.Empty;

        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class Conceptos
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdConcepto { get; set; } = 0;

        [DataMember]
        public string Concepto { get; set; } = string.Empty;

        [DataMember]

        public string TipoConcepto { get; set; } = string.Empty;

        [DataMember]
        public string Descripcion { get; set; } = string.Empty;

        [DataMember]
        public string Unidad { get; set; } = string.Empty;

        [DataMember]
        public bool Salarial { get; set; } = false;

        [DataMember]
        public bool Fijo { get; set; } = false;

        [DataMember]
        public bool Liquidable { get; set; } = false;

        [DataMember]
        public bool Excluyente { get; set; } = false;

        [DataMember]
        public bool CantidadEditable { get; set; } = false;

        [DataMember]
        public bool MontoEditable { get; set; } = false;

        [DataMember]
        public bool UsaCantidad { get; set; } = false;

        [DataMember]
        public bool UsaMonto { get; set; } = false;

        [DataMember]
        public bool FormulaDefinida { get; set; } = false;

        [DataMember]
        public bool ImprimeComprobante { get; set; } = false;

        [DataMember]
        public bool ImprimeAcumulado { get; set; } = false;

        [DataMember]
        public decimal FactorRedondeo { get; set; } = 0;

        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }

    [DataContract]
    public class ConceptoFormula
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;

        [DataMember]
        public int IdConceptoFormula { get; set; } = 0;

        [DataMember]
        public int IdConcepto { get; set; } = 0;

        [DataMember]

        public int Secuencia { get; set; } = 0;

        [DataMember]
        public int ValorInicial { get; set; } = 0;

        [DataMember]
        public int ValorFinal { get; set; } = 0;

        [DataMember]
        public int CantidadMonto { get; set; } = 0;

        [DataMember]
        public int NivelFormula { get; set; } = 0;

        [DataMember]
        public bool UsaCantidad { get; set; } = false;

        [DataMember]
        public bool UsaMonto { get; set; } = false;

        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }

    [DataContract]
    public class ConceptoLiquidacion
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;

        [DataMember]
        public int IdConceptoLiquidacion { get; set; } = 0;

        [DataMember]
        public int IdConcepto { get; set; } = 0;

        [DataMember]
        public DateTime FechaLiquidacion { get; set; } = DateTime.Now;

        [DataMember]
        public string Comentarios { get; set; } = string.Empty;

        [DataMember]
        public int NumeroLiquidacion { get; set; } = 0;

        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }

    [DataContract]
    public class EmpleadoConceptoLiquidacion
    {
        [DataMember]
        public string Accion { get; set; } = string.Empty;
        [DataMember]
        public int IdConceptoLiquidacion { get; set; } = 0;
        [DataMember]
        public int IdEmpleado { get; set; } = 0;
        [DataMember]
        public DateTime FechaLiquidacion { get; set; } = DateTime.Now;
        [DataMember]
        public int MontoCalculado { get; set; } = 0;
        [DataMember]
        public int MontoPagar { get; set; } = 0;
        [DataMember]
        public string Observaciones { get; set; } = string.Empty;
        [DataMember]
        public string UsuarioCreacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [DataMember]
        public string UsuarioModificacion { get; set; } = string.Empty;
        [DataMember]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }


}
