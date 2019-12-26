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
    public class EmpleadoConceptoController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: EmpleadoConcepto
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarEmpleadoConcepto(new EmpleadoConcepto
            {
                Accion = "CONSULTAR",
                FechaUltimaAplicacion = DateTime.Now,
                FechaProximaAplicacion = DateTime.Now,
                FechaVencimiento = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });
            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoConceptos
            {
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                NumeroCuotas = dataRow.Field<int>("NUMEROCUOTAS"),
                CuotasAplicadas = dataRow.Field<int>("CUOTASAPLICADAS"),
                SaldoInicial = dataRow.Field<int>("SALDOINICIAL"),
                Saldo = dataRow.Field<int>("SALDO"),
                Acumulado = dataRow.Field<int>("ACUMULADO"),
                Comentarios = dataRow.Field<string>("COMENTARIOS"),


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


        // GET: EmpleadoConcepto/Create
        public ActionResult Create()
        {
            ViewBag.ListaEmpleados = GetEmpleado();
            return View();
        }

        // POST: EmpleadoConcepto/Create
        [HttpPost]
        public ActionResult Create(EmpleadoConcepto EmpleadoC)
        {
            try
            {
                var objeto = new EmpleadoConcepto
                {
                    Accion = "INSERTAR",
                    IdConcepto = EmpleadoC.IdConcepto,
                    IdEmpleado = EmpleadoC.IdEmpleado,
                    NumeroCuotas = EmpleadoC.NumeroCuotas,
                    CuotasAplicadas = EmpleadoC.CuotasAplicadas,
                    SaldoInicial = EmpleadoC.SaldoInicial,
                    Saldo = EmpleadoC.Saldo,
                    Acumulado = EmpleadoC.Acumulado,
                    FechaUltimaAplicacion = EmpleadoC.FechaUltimaAplicacion,
                    FechaProximaAplicacion = EmpleadoC.FechaProximaAplicacion,
                    FechaVencimiento = EmpleadoC.FechaVencimiento,
                    Cantidad = EmpleadoC.Cantidad,
                    Monto = EmpleadoC.Monto,
                    Comentarios = EmpleadoC.Comentarios,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarEmpleadoConcepto(objeto);

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

        // GET: EmpleadoConcepto/Edit/5
        public ActionResult Edit(int id, int dato)
        {
            var dt = _servicio.ConsultarEmpleadoConcepto(new EmpleadoConcepto
            {
                Accion = "CONSULTAR_EMPLEADO_CONCEPTO",
                IdConcepto = id,
                IdEmpleado = dato,
                FechaUltimaAplicacion = DateTime.Now,
                FechaProximaAplicacion = DateTime.Now,
                FechaVencimiento = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });
            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoConceptos
            {
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                NumeroCuotas = dataRow.Field<int>("NUMEROCUOTAS"),
                CuotasAplicadas = dataRow.Field<int>("CUOTASAPLICADAS"),
                SaldoInicial = dataRow.Field<int>("SALDOINICIAL"),
                Saldo = dataRow.Field<int>("SALDO"),
                Acumulado = dataRow.Field<int>("ACUMULADO"),
                FechaUltimaAplicacion = dataRow.Field<DateTime>("FECHAULTIMAAPLICACION"),
                FechaProximaAplicacion = dataRow.Field<DateTime>("FECHAPROXIMAAPLICACION"),
                FechaVencimiento = dataRow.Field<DateTime>("FECHAVENCIMIENTO"),
                Cantidad = dataRow.Field<int>("CANTIDAD"),
                Monto = dataRow.Field<int>("MONTO"),
                Comentarios = dataRow.Field<string>("COMENTARIOS"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION"),
                UsuarioModificacion = dataRow.Field<string>("USUARIOMODIFICACION"),
                FechaModificacion = dataRow.Field<DateTime>("FECHAMODIFICACION")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: EmpleadoConcepto/Edit/5
        [HttpPost]
        public ActionResult Edit(EmpleadoConcepto EmpleadoC)
        {
            try
            {
                var objeto = new EmpleadoConcepto
                {
                    Accion = "ACTUALIZAR",
                    IdConcepto = EmpleadoC.IdConcepto,
                    IdEmpleado = EmpleadoC.IdEmpleado,
                    NumeroCuotas = EmpleadoC.NumeroCuotas,
                    CuotasAplicadas = EmpleadoC.CuotasAplicadas,
                    SaldoInicial = EmpleadoC.SaldoInicial,
                    Saldo = EmpleadoC.Saldo,
                    Acumulado = EmpleadoC.Acumulado,
                    FechaUltimaAplicacion = EmpleadoC.FechaUltimaAplicacion,
                    FechaProximaAplicacion = EmpleadoC.FechaProximaAplicacion,
                    FechaVencimiento = EmpleadoC.FechaVencimiento,
                    Cantidad = EmpleadoC.Cantidad,
                    Monto = EmpleadoC.Monto,
                    Comentarios = EmpleadoC.Comentarios,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };
                var dt = _servicio.ProcesarEmpleadoConcepto(objeto);

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

        // GET: EmpleadoConcepto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoConcepto/Delete/5
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
