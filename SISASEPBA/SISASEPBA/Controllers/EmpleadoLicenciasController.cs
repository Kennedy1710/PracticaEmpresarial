using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    public class EmpleadoLicenciasController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: EmpleadoLicencias
        [Authorize]
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarEmpleadoLicencia(new EmpleadoLicencia { Accion = "CONSULTAR", FechaVencimiento = DateTime.Now, 
                FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoLicencia
            {
                IdEmpleadoLicencia = dataRow.Field<int>("IDEMPLEADOLICENCIA"),
                IdEmpleado = dataRow.Field<string>("EMPLEADO"),
                IdTipoLicencia = dataRow.Field<string>("TIPOLICENCIA"),
                FechaVencimiento = dataRow.Field<DateTime>("FECHAVENCIMIENTO"),
                Estado = dataRow.Field<bool>("ESTADO")

            }).ToList();

            return View(usr);
        }

        // GET: EmpleadoLicencias/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        public List<Models.TipoLicencias> GetTipoLicencias()
        {
            var dt = _servicio.ConsultarTipoLicencia(new TipoLicencia
            {
                Accion = "CONSULTAR_TIPOLICENCIA",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.TipoLicencias
            {
                IdTipoLicencia = dataRow.Field<int>("IDTIPOLICENCIA"),
                Alias = dataRow.Field<string>("ALIAS"),
                Estado = dataRow.Field<bool>("ESTADO"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),

            }).ToList();

            return list;
        }

        // GET: EmpleadoLicencias/Create
        public ActionResult Create()
        {
            ViewBag.ListaDepartamentos = GetTipoLicencias();
            ViewBag.Empleados = GetEmpleado();
            return View();
        }

        // POST: EmpleadoLicencias/Create
        [HttpPost]
        public ActionResult Create(EmpleadoLicencia empleadoLicencia)
        {
            try
            {
                var objeto = new EmpleadoLicencia
                {
                    Accion = "INSERTAR",
                    IdEmpleado = empleadoLicencia.IdEmpleado,
                    IdTipoLicencia = empleadoLicencia.IdTipoLicencia,
                    FechaVencimiento = empleadoLicencia.FechaVencimiento,
                    Estado = true,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarEmpleadoLicencia(objeto);

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

        // GET: EmpleadoLicencias/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TipoLicencia = GetTipoLicencias();

            var dt = _servicio.ConsultarEmpleadoLicencia(new EmpleadoLicencia
            {
                Accion = "CONSULTAR_DEPARTAMENTO",
                FechaVencimiento = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.EmpleadoLicencia
            {
                IdTipoLicencia = dataRow.Field<string>("IDTIPOLICENCIA"),
                FechaVencimiento = dataRow.Field<DateTime>("FECHADEVENCIMIENTO"),
                Estado = dataRow.Field<bool>("ESTADO"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")
                //    UsuarioModificacion = dataRow.Field<string>("USUARIOMODIFICACION"),
                //    FechaModificacion = dataRow.Field<DateTime>("FECHAMODIFICACION")
            }).FirstOrDefault();

            return View(usr);
        }

        // POST: Departamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Departamento departamento)
        {
            try
            {
                var objeto = new Departamento
                {
                    Accion = "ACTUALIZAR",
                    IdDepartamento = departamento.IdDepartamento,
                    Alias = departamento.Alias,
                    Descripcion = departamento.Descripcion,
                    Estado = departamento.Estado,
                    UsuarioCreacion = departamento.UsuarioCreacion,
                    FechaCreacion = departamento.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarDepartamentos(objeto);
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

        // GET: EmpleadoLicencias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoLicencias/Delete/5
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
