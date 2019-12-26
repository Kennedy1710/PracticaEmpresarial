using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using SISASEPBA.ServicioAsepba;
using System.IO;

namespace SISASEPBA.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Empleados
        [Authorize]
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarEmpleado(new Empleado {Accion = "CONSULTAR", FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now, FechaNacimiento = DateTime.Now, FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now, UltimoCambioVac = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Empleado
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

            return View(usr);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public List<Models.Departamento> Departamentos()
        {
            var dt = _servicio.ConsultarDepartamentos(new Departamento
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Departamento
            {
                IdDepartamento = dataRow.Field<int>("IDDEPARTAMENTO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();

            return list;
        }

        public List<Models.Nacionalidad> Nacionalidad()
        {
            var dt = _servicio.ConsultarNacionalidad(new Nacionalidad
            {
                Accion = "CONSULTAR_NACIONALIDAD",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Nacionalidad
            {
                IdNacionalidad = dataRow.Field<int>("IDNACIONALIDAD"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),



            }).ToList();

            return list;
        }

        public List<Models.Puesto> Puestos()
        {
            var dt = _servicio.ConsultarPuestos(new Puesto
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Puesto
            {
                IdPuesto = dataRow.Field<int>("IDPUESTO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();

            return list;
        }

        public List<Models.Nomina> Nominas()
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

        public List<Models.ControlVacacional> ControlVacacional()
        {
            var dt = _servicio.ConsultarControlVacacional(new ControlVacacional
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.ControlVacacional
            {
                IdRegimenVacacional = dataRow.Field<int>("IDREGIMENVACACIONAL"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();

            return list;
        }

        public List<Models.FormaPago> FormaPago()
        {
            var dt = _servicio.ConsultarFormaPago(new FormaPago
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.FormaPago
            {
                IdFormaPago = dataRow.Field<int>("IDFORMAPAGO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Estado = dataRow.Field<bool>("ESTADO"),
                Descripcion = dataRow.Field<string>("DESCRIPCION")

            }).ToList();

            return list;
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return View();
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            
            ViewBag.Nacionalidad = Nacionalidad();
            ViewBag.Departamento = Departamentos();
            ViewBag.Puesto = Puestos();
            ViewBag.Nomina = Nominas();
            ViewBag.ControlVacacional = ControlVacacional();
            ViewBag.FormaPago = FormaPago();
            //ViewBag.Departamento = new SelectList(Departamentos().Select(x => new { Id = x.IdDepartamento, Nombre = x.Descripcion }), "Id", "Nombre ");

            var dt = _servicio.ConsultarEmpleado(new Empleado{Accion = "CONSULTAR_EMPLEADO", IdEmpleado = id,
                FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now, FechaNacimiento =DateTime.Now,
                FechaIngreso = DateTime.Now, FechaSalida = DateTime.Now, UltimoCambioVac = DateTime.Now});

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Empleado
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
                TipoIdentificacion = dataRow.Field<string>("TIPOIDENTIFICACION"),
                NumeroIdentificacion = dataRow.Field<int>("NUMEROIDENTIFICACION"),
                AhorroAsociacion = dataRow.Field<decimal>("AHORROASOCIACION"),
                TelefonoPrincipal = dataRow.Field<string>("TELEFONOPRINCIPAL"),
                TelefonoSecundario = dataRow.Field<string>("TELEFONOSECUNDARIO"),
                TelefonoEmergencia = dataRow.Field<string>("TELEFONOEMERGENCIA"),
                ContactoEmergencia = dataRow.Field<string>("CONTACTOEMERGENCIA"),
                FechaNacimiento = dataRow.Field<DateTime>("FECHANACIMIENTO"),
                FechaIngreso = dataRow.Field<DateTime>("FECHAINGRESO"),
                FechaSalida = dataRow.Field<DateTime>("FECHASALIDA"),
                TipoDeSangre = dataRow.Field<string>("TIPODESANGRE"),
                DireccionDomicilio = dataRow.Field<string>("DIRECCIONDOMICILIO"),
                Sexo = dataRow.Field<string>("SEXO"),
                EstadoCivil = dataRow.Field<string>("ESTADOCIVIL"),
                Estado = dataRow.Field<string>("ESTADO"),
                SubEstado = dataRow.Field<string>("SUBESTADO"),
                CorreoElectronico = dataRow.Field<string>("CORREOELECTRONICO"),
                ConyugeDependiente = dataRow.Field<bool>("CONYUGEDEPENDIENTE"),
                HijosDependientes = dataRow.Field<int>("HIJOSDEPENDIENTES"),
                NumeroAsegurado = dataRow.Field<string>("NUMEROASEGURADO"),
                VacacionesPendientes = dataRow.Field<int>("VACACIONESPENDIENTES"),
                UltimoCambioVac = dataRow.Field<DateTime>("ULTIMOCAMBIOVAC"),
                SalarioReferencia = dataRow.Field<decimal>("SALARIOREFERENCIA"),
                Foto = dataRow.Field<byte[]>("FOTO"),
                ObservacionesGenerales = dataRow.Field<string>("OBSERVACIONESGENERALES"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Edit(Empleado empleado, HttpPostedFileBase img)
        {

            if (img != null && img.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var imagen = new BinaryReader(img.InputStream))
                {
                    imageData = imagen.ReadBytes(img.ContentLength);
                }

                empleado.Foto = imageData;
            }


            try
            {
                var objeto = new Empleado
                {
                    Accion = "ACTUALIZAR",
                    IdEmpleado = empleado.IdEmpleado,
                    IdNacionalidad = empleado.IdNacionalidad,
                    IdDepartamento = empleado.IdDepartamento,
                    IdPuesto = empleado.IdPuesto,
                    IdNomina = empleado.IdNomina,
                    IdFormaPago = empleado.IdFormaPago,
                    IdRegimenVacacional = empleado.IdRegimenVacacional,
                    CodigoEmpleado = empleado.CodigoEmpleado,
                    PrimerNombre = empleado.PrimerNombre,
                    SegundoNombre = empleado.SegundoNombre,
                    PrimerApellido = empleado.PrimerApellido,
                    SegundoApellido = empleado.SegundoApellido,
                    TipoIdentificacion = empleado.TipoIdentificacion,
                    NumeroIdentificacion = empleado.NumeroIdentificacion,
                    AhorroAsociacion = empleado.AhorroAsociacion,
                    TelefonoPrincipal = empleado.TelefonoPrincipal,
                    TelefonoSecundario = empleado.TelefonoSecundario,
                    TelefonoEmergencia = empleado.TelefonoEmergencia,
                    ContactoEmergencia = empleado.ContactoEmergencia,
                    FechaNacimiento = empleado.FechaNacimiento,
                    FechaIngreso = empleado.FechaIngreso,
                    FechaSalida = empleado.FechaSalida,
                    TipoDeSangre = empleado.TipoDeSangre,
                    DireccionDomicilio = empleado.DireccionDomicilio,
                    Sexo = empleado.Sexo,
                    EstadoCivil = empleado.EstadoCivil,
                    Estado = empleado.Estado,
                    SubEstado = empleado.SubEstado,
                    CorreoElectronico = empleado.CorreoElectronico,
                    ConyugeDependiente = empleado.ConyugeDependiente,
                    HijosDependientes = empleado.HijosDependientes,
                    NumeroAsegurado = empleado.NumeroAsegurado,
                    VacacionesPendientes = empleado.VacacionesPendientes,
                    UltimoCambioVac = empleado.UltimoCambioVac,
                    SalarioReferencia = empleado.SalarioReferencia,
                    Foto = empleado.Foto,
                    ObservacionesGenerales = empleado.ObservacionesGenerales,
                    UsuarioCreacion = empleado.UsuarioCreacion,
                    FechaCreacion = empleado.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarEmpleado(objeto);

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

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleados/Delete/5
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
