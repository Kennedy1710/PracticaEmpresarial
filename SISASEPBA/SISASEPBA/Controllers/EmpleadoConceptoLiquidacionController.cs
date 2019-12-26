using SISASEPBA.ServicioAsepba;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISASEPBA.Controllers
{
    public class EmpleadoConceptoLiquidacionController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Empleado concepto liquidacion
        [Authorize]
        public ActionResult Index()
        {

            var dt = _servicio.ConsultarEmpleadoConceptoLiquidacion(new EmpleadoConceptoLiquidacion
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaLiquidacion=DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoConceptoLiquidacion
            {
                IdConceptoLiquidacion = dataRow.Field<int>("IDCONCEPTOLIQUIDACION"),
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                FechaLiquidacion = dataRow.Field<DateTime>("FECHALIQUIDACION"),
                MontoCalculado = dataRow.Field<int>("MONTOCALCULADO"),
                MontoPagar = dataRow.Field<int>("MONTOPAGAR"),
                Observaciones= dataRow.Field<string>("OBSERVACIONES"),


            }).ToList();
            return View(usr);
        }

        // GET: EmpleadoConceptoLiquidacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Listar empleados
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

        public List<Models.ConceptoLiquidacion> GetConceptoLiquidacion()
        {
            var dt = _servicio.ConsultarConceptoLiquidacion(new ConceptoLiquidacion
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaLiquidacion = DateTime.Now
               
            });

            var listCL = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.ConceptoLiquidacion
            {
                IdConceptoLiquidacion = dataRow.Field<int>("IDCONCEPTOLIQUIDACION"),
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                FechaLiquidacion = dataRow.Field<DateTime>("FECHALIQUIDACION"),
                Comentarios = dataRow.Field<string>("COMENTARIOS"),
                NumeroLiquidacion = dataRow.Field<int>("NUMEROLIQUIDACION"),
                

            }).ToList();

            return listCL;
        }
        // GET: EmpleadoConceptoLiquidacion/Create
        public ActionResult Create()
        {

            ViewBag.conceptoLiquidacion= GetConceptoLiquidacion();

             ViewBag.Empleados = GetEmpleado();

            return View();
        }

        // POST: Conceptos/Create
        [HttpPost]
        public ActionResult Create(EmpleadoConceptoLiquidacion conceptos)
        {
            try
            {
                var objeto = new EmpleadoConceptoLiquidacion
                {
                    Accion = "INSERTAR",
                    IdConceptoLiquidacion = conceptos.IdConceptoLiquidacion,
                    IdEmpleado = conceptos.IdEmpleado,
                    FechaLiquidacion = conceptos.FechaLiquidacion,
                    MontoCalculado = conceptos.MontoCalculado,
                    MontoPagar = conceptos.MontoPagar,
                    Observaciones = conceptos.Observaciones,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarEmpleadoConceptoLiquidacion(objeto);

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



        // GET: EmpleadoConceptoLiquidacion/Edit/5
        public ActionResult Edit(int id,int dato)
        {
            ViewBag.conceptoLiquidacion = GetConceptoLiquidacion();

            var dt = _servicio.ConsultarEmpleadoConceptoLiquidacion(new EmpleadoConceptoLiquidacion
            {
                Accion = "CONSULTAR2",
                IdConceptoLiquidacion = id,
                IdEmpleado=dato,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaLiquidacion=DateTime.Now

            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoConceptoLiquidacion
            {
                IdConceptoLiquidacion = dataRow.Field<int>("IDCONCEPTOLIQUIDACION"),
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                FechaLiquidacion = dataRow.Field<DateTime>("FECHALIQUIDACION"),
                MontoCalculado = dataRow.Field<int>("MONTOCALCULADO"),
                MontoPagar = dataRow.Field<int>("MONTOPAGAR"),
                Observaciones = dataRow.Field<string>("OBSERVACIONES"),


            }).FirstOrDefault();

            return View(usr);

        }

        // POST: empleado Concepto liquidacion/Edit/5
        [HttpPost]
        public ActionResult Edit(EmpleadoConceptoLiquidacion EmpconceptoLQ)
        {

            try
            {
                var objeto = new EmpleadoConceptoLiquidacion
                {
                    Accion = "ACTUALIZAR",
                    IdConceptoLiquidacion = EmpconceptoLQ.IdConceptoLiquidacion,
                    IdEmpleado = EmpconceptoLQ.IdEmpleado,
                    FechaLiquidacion = EmpconceptoLQ.FechaLiquidacion,
                    MontoCalculado = EmpconceptoLQ.MontoCalculado,
                    MontoPagar= EmpconceptoLQ.MontoPagar,
                    Observaciones = EmpconceptoLQ.Observaciones,
                    UsuarioCreacion = EmpconceptoLQ.UsuarioCreacion,
                    FechaCreacion = EmpconceptoLQ.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarEmpleadoConceptoLiquidacion(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch
            {
                return View();
            }

        }
        // GET: EmpleadoConceptoLiquidacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoConceptoLiquidacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
