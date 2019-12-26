using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    [Authorize]
    public class EmpleadoConceptoNominaController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: EmpleadoConceptoNomina
        public ActionResult Index()
        {
            ViewBag.Empleado = GetEmpleado();
            var dt = _servicio.ConsultarEmpleadoConceptoNomina(new EmpleadoConceptoNomina
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoConceptoNomina
            {
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                IdNomina = dataRow.Field<int>("IDNOMINA"),
                IdConceptoLiquidacion = dataRow.Field<int>("IDCONCEPTOLIQUIDACION"),
                ConsecutivoNomina = dataRow.Field<int>("CONSECUTIVONOMINA"),
                Cantidad = dataRow.Field<int>("CANTIDAD"),
                Monto = dataRow.Field<int>("MONTO"),
                Total = dataRow.Field<int>("TOTAL")

            }).ToList();

            return View(usr);
        }

        public List<Models.Empleado> GetEmpleado()
        {
            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Empleado
            {
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdNacionalidad = dataRow.Field<string>("NACIONALIDAD"),
                IdDepartamento = dataRow.Field<string>("DEPARTAMENTO"),
                IdPuesto = dataRow.Field<string>("PUESTO"),
                IdNomina = dataRow.Field<string>("NOMINA"),
                IdFormaPago = dataRow.Field<string>("FORMAPAGO"),
                IdRegimenVacacional = dataRow.Field<string>("CONTROLVACACIONAL"),
                CodigoEmpleado = dataRow.Field<string>("CODIGOEMPLEADO"),
                PrimerNombre = dataRow.Field<string>("PRIMERNOMBRE"),
                SegundoNombre = dataRow.Field<string>("SEGUNDONOMBRE"),
                PrimerApellido = dataRow.Field<string>("PRIMERAPELLIDO"),
                SegundoApellido = dataRow.Field<string>("SEGUNDOAPELLIDO"),
                Estado = dataRow.Field<string>("ESTADO"),
                NumeroIdentificacion = dataRow.Field<int>("NUMEROIDENTIFICACION"),
                CorreoElectronico = dataRow.Field<string>("CORREOELECTRONICO"),
                TelefonoPrincipal = dataRow.Field<string>("TELEFONOPRINCIPAL")

            }).ToList();

            return list;
        }

        public List<Models.Nomina> GetNominas()
        {
            var dt = _servicio.ConsultarNomina(new Nomina
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Nomina
            {
                IdNomina = dataRow.Field<int>("IDNOMINA"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<string>("ESTADO"),

            }).ToList();

            return list;
        }


        // GET: EmpleadoConceptoNomina/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoConceptoNomina/Create
        public ActionResult Create()
        {
            ViewBag.ListaEmpleados = GetEmpleado();
            ViewBag.ListaNominas = GetNominas();
            return View();
        }

        // POST: EmpleadoConceptoNomina/Create
        [HttpPost]
        public ActionResult Create(Models.EmpleadoConceptoNomina EmpCN)
        {
            try
            {
                var objeto = new EmpleadoConceptoNomina
                {
                    Accion = "INSERTAR",
                    IdEmpleado = EmpCN.IdEmpleado,
                    IdConcepto = EmpCN.IdConcepto,
                    IdNomina = EmpCN.IdNomina,
                    IdConceptoLiquidacion = EmpCN.IdConceptoLiquidacion,
                    ConsecutivoNomina = EmpCN.ConsecutivoNomina,
                    Cantidad = EmpCN.Cantidad,
                    Monto = EmpCN.Monto,
                    Total = EmpCN.Total,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarEmpleadoConceptoNomina(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoConceptoNomina/Edit/5
        public ActionResult Edit(int id, int dato1, int dato2, int dato3)
        {
            ViewBag.ListaEmpleados = GetEmpleado();
            ViewBag.ListaNominas = GetNominas();
            var dt = _servicio.ConsultarEmpleadoConceptoNomina(new EmpleadoConceptoNomina
            {
                Accion = "CONSULTAR_CONCEPTO_NOMINA",
                IdEmpleado = id,
                IdConcepto = dato1,
                IdNomina = dato2,
                IdConceptoLiquidacion = dato3,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });
            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoConceptoNomina
            {
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                IdNomina = dataRow.Field<int>("IDNOMINA"),
                IdConceptoLiquidacion = dataRow.Field<int>("IDCONCEPTOLIQUIDACION"),
                ConsecutivoNomina = dataRow.Field<int>("CONSECUTIVONOMINA"),
                Cantidad = dataRow.Field<int>("CANTIDAD"),
                Monto = dataRow.Field<int>("MONTO"),
                Total = dataRow.Field<int>("TOTAL"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: EmpleadoConceptoNomina/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.EmpleadoConceptoNomina EmpCN)
        {
            try
            {
                var objeto = new EmpleadoConceptoNomina
                {
                    Accion = "ACTUALIZAR",
                    IdEmpleado = EmpCN.IdEmpleado,
                    IdConcepto = EmpCN.IdConcepto,
                    IdNomina = EmpCN.IdNomina,
                    IdConceptoLiquidacion = EmpCN.IdConceptoLiquidacion,
                    ConsecutivoNomina = EmpCN.ConsecutivoNomina,
                    Cantidad = EmpCN.Cantidad,
                    Monto = EmpCN.Monto,
                    Total = EmpCN.Total,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };
                var dt = _servicio.ProcesarEmpleadoConceptoNomina(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit");
                }
            }
            catch
            {
                return View();
            }
        }

        
    }
}
