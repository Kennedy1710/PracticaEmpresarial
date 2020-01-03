using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using SISASEPBA.ServicioAsepba;
//using SISASEPBA.Models;


namespace SISASEPBA.Controllers
{
    public class AccionesDePersonalController : Controller
    {

        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();

        #region FH
        public List<Models.Empleado> Empleados()
        {
            try
            {
                var dt = _servicio.ConsultarEmpleado(new Empleado
                {
                    Accion = "CEA",
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
                    NombreCompleto = dataRow.Field<string>("NOMBRE"),


                }).ToList();

                return list;
            }
            catch (Exception)
            {
                return new List<Models.Empleado>();
            }

        }
        public List<Models.TipoAccion> TipoAcciones()
        {
            try
            {
                var dt = _servicio.ConsultarTipoAccion(new TipoAccion
                {
                    Accion = "CONSULTAR",
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now
                });

                var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.TipoAccion
                {
                    IdTipoAP = dataRow.Field<int>("IDTIPOAP"),
                    Alias = dataRow.Field<string>("ALIAS"),
                    Descripcion = dataRow.Field<string>("DESCRIPCION"),

                }).ToList();

                return list;
            }
            catch (Exception)
            {
                return new List<Models.TipoAccion>();
            }
        }
        public List<Models.AccionPersonal> AccionPersonals(int idEmpleado,int idAccion,string desde,string hasta)
        {
            try
            {
                var dt = _servicio.ConsultarAccionDePersonal(new AccionDePersonal
                {
                    Accion = "CONSULTAR",
                    IdEmpleado =idEmpleado,
                    IdAccionPersonal = idAccion,

                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    FechaRige = string.IsNullOrEmpty(desde)? DateTime.Now : Convert.ToDateTime(desde) ,
                    FechaVence = string.IsNullOrEmpty(hasta) ? DateTime.Now : Convert.ToDateTime(hasta),
                    UltimoCambioVacacional = DateTime.Now
                });

                var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.AccionPersonal
                {
                    Nombre = dataRow.Field<string>("NOMBRE"),
                    CodigoEmpleado = dataRow.Field<string>("CodigoEmpleado"),
                    AccionDePersonal = dataRow.Field<string>("TipoAccion"),
                    Estado = dataRow.Field<string>("EstadoAP"),
                    FechaCreacion = dataRow.Field<DateTime>("FechaCreacion"),

                }).ToList();

                return list;
            }
            catch (Exception)
            {
                return new List<Models.AccionPersonal>();
            }
        }

        public PartialViewResult Consultar(string idEmpleado,string idAccion,string desde,string hasta)
        {
            var model = new Models.AccionPersonalViewModels
            {
                Empleados = Empleados(),
                TipoAccions = TipoAcciones(),
                AccionPersonals = AccionPersonals(Convert.ToInt32(idEmpleado), Convert.ToInt32(idAccion), desde, hasta)
            };
            return PartialView("_Index",model );

        }
        #endregion

        // GET: AccionesDePersonal
        public ActionResult Index()
        {
            var model = new Models.AccionPersonalViewModels
            {
                Empleados = Empleados(),
                TipoAccions = TipoAcciones(),
                AccionPersonals = AccionPersonals(0, 0, "","")
            };
            return View(model);
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

        // GET: AccionesDePersonal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccionesDePersonal/Create
        public ActionResult APContratacion()
        {
            ViewBag.Nacionalidad = Nacionalidad();
            ViewBag.Departamento = Departamentos();
            ViewBag.Puesto = Puestos();
            ViewBag.Nomina = Nominas();
            ViewBag.ControlVacacional = ControlVacacional();
            ViewBag.FormaPago = FormaPago();

            return View();
        }




        // POST: AccionesDePersonal/Create
        [HttpPost]
        public ActionResult APContratacion(AccionDePersonal contratacion)
        {
            var objeto = new AccionDePersonal
            {
                Accion = "APCONTRATACION",
                IdTipoAP = 1,
                FechaRige = contratacion.FechaRige,
                FechaVence = contratacion.FechaVence,
                IdNacionalidad = contratacion.IdNacionalidad,
                IdDepartamento = contratacion.IdDepartamento,
                IdPuesto = contratacion.IdPuesto,
                IdNomina = contratacion.IdNomina,
                IdFormaPago = contratacion.IdFormaPago,
                IdRegimenVacacional = contratacion.IdRegimenVacacional,
                CodigoEmpleado = contratacion.CodigoEmpleado,
                EmpleadoPrimerNombre = contratacion.EmpleadoPrimerNombre,
                EmpleadoSegundoNombre = contratacion.EmpleadoSegundoNombre,
                EmpleadoPrimerApellido = contratacion.EmpleadoPrimerApellido,
                EmpleadoSegundoApellido = contratacion.EmpleadoSegundoApellido,
                TipoIdentificacion = contratacion.TipoIdentificacion,
                NumeroIdentificacion = contratacion.NumeroIdentificacion,
                FechaNacimiento = contratacion.FechaNacimiento,
                Sexo = contratacion.Sexo,
                TipoSangre = contratacion.TipoSangre,
                NumeroAsegurado = contratacion.NumeroAsegurado,
                CorreoElectronico = contratacion.CorreoElectronico,
                DireccionDomicilio = contratacion.DireccionDomicilio,
                EstadoCivil = contratacion.EstadoCivil,
                ConyugeDependiente = contratacion.ConyugeDependiente,
                HijosDependientes = contratacion.HijosDependientes,
                TelefonoPrincipal = contratacion.TelefonoPrincipal,
                TelefonoSecundario = contratacion.TelefonoSecundario,
                TelefonoEmergencia = contratacion.TelefonoEmergencia,
                ContactoEmergencia = contratacion.ContactoEmergencia,
                Estado = "ACT",
                SubEstado = contratacion.SubEstado,
                AhorroAsociacion = contratacion.AhorroAsociacion,
                SalarioReferencia = contratacion.SalarioReferencia,
                Foto = contratacion.Foto,
                ObservacionesGenerales = contratacion.ObservacionesGenerales,
                ObservacionesAP = contratacion.ObservacionesAP,
                UsuarioCreacion = User.Identity.Name,
                FechaCreacion = DateTime.Now,
                UsuarioModificacion = User.Identity.Name,
                FechaModificacion = DateTime.Now,
                FechaAplicacion = DateTime.Now,
                FechaAprobacion = DateTime.Now,
                FechaCancelacion = DateTime.Now,
                FechaDenegacion = DateTime.Now,
                UltimoCambioVacacional = DateTime.Now,
                
                
            };

            var dt = _servicio.ProcesarAccionDePersonal(objeto);

            if (dt.IsSuccess)
            {
                return RedirectToAction("Index", "Empleados");
            }
            else
            {
                return View("Create");
            }
        }

        // GET: AccionesDePersonal/Edit/5
        public ActionResult APCambioDeNombre(int id)
        {
            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR_EMPLEADO",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDeNombre
            {
                //IdAccionPersonal = dataRow.Field<int>("IDACCIONPERSONAL"),
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                EmpleadoPrimerNombre = dataRow.Field<string>("PRIMERNOMBRE"),
                EmpleadoSegundoNombre = dataRow.Field<string>("SEGUNDONOMBRE"),
                EmpleadoPrimerApellido = dataRow.Field<string>("PRIMERAPELLIDO"),
                EmpleadoSegundoApellido = dataRow.Field<string>("SEGUNDOAPELLIDO"),
                //UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                //FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDeNombre(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODENOMBRE",
                    IdTipoAP = 2002,
                    IdEmpleado = accion.IdEmpleado,
                    EmpleadoPrimerNombre = accion.EmpleadoPrimerNombre,
                    EmpleadoSegundoNombre = accion.EmpleadoSegundoNombre,
                    EmpleadoPrimerApellido = accion.EmpleadoPrimerApellido,
                    EmpleadoSegundoApellido = accion.EmpleadoSegundoApellido,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    FechaRige = DateTime.Now,
                    FechaVence = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APAscenso(int id)
        {
            ViewBag.Departamento = Departamentos();
            ViewBag.Puesto = Puestos();
            ViewBag.Nomina = Nominas();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APAscenso
            {
                
                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdDepartamento = dataRow.Field<string>("DEPARTAMENTO"),
                IdPuesto = dataRow.Field<string>("PUESTO"),
                IdNomina = dataRow.Field<string>("NOMINA"),
                SalarioReferencia = dataRow.Field<decimal>("SALARIOREFERENCIA")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APAscenso(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APASCENSO",
                    IdTipoAP = 4,
                    IdEmpleado = accion.IdEmpleado,
                    IdDepartamento = accion.IdDepartamento,
                    IdPuesto = accion.IdPuesto,
                    IdNomina = accion.IdNomina,
                    SalarioReferencia = accion.SalarioReferencia,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    FechaRige = DateTime.Now,
                    FechaVence = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APAusenciaJustificada(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APAusencias
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APAusenciaJustificada(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APAUSENCIAJUSTIFICADA",
                    IdTipoAP = 2003,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APAusenciaInjustificada(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APAusencias
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APAusenciaInjustificada(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APAUSENCIAINJUSTIFICADA",
                    IdTipoAP = 2004,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDeDepartamento(int id)
        {
            ViewBag.Departamento = Departamentos();
            ViewBag.Puesto = Puestos();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDeDepartamento
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdDepartamento = dataRow.Field<string>("DEPARTAMENTO"),
                IdPuesto = dataRow.Field<string>("PUESTO")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDeDepartamento(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODEDEPARTAMENTO",
                    IdTipoAP = 2006,
                    IdEmpleado = accion.IdEmpleado,
                    IdDepartamento = accion.IdDepartamento,
                    IdPuesto = accion.IdPuesto,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaRige = DateTime.Now,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDeIdentificacion(int id)
        {
            ViewBag.Nacionalidad = Nacionalidad();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDeIdentificacion
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdNacionalidad = dataRow.Field<string>("NACIONALIDAD"),
                TipoIdentificacion = dataRow.Field<string>("TIPOIDENTIFICACION"),
                NumeroIdentificacion = dataRow.Field<int>("NUMEROIDENTIFICACION")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDeIdentificacion(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODEIDENTIFICACION",
                    IdTipoAP = 2007,
                    IdEmpleado = accion.IdEmpleado,
                    IdNacionalidad = accion.IdNacionalidad,
                    TipoIdentificacion = accion.TipoIdentificacion,
                    NumeroIdentificacion = accion.NumeroIdentificacion,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaRige = DateTime.Now,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDeNomina(int id)
        {
            ViewBag.Nomina = Nominas();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDeNomina
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdNomina = dataRow.Field<string>("NOMINA")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDeNomina(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODENOMINA",
                    IdTipoAP = 2008,
                    IdEmpleado = accion.IdEmpleado,
                    IdNomina = accion.IdNomina,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaRige = DateTime.Now,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDeNumeroDeSeguro(int id)
        {
            ViewBag.Nomina = Nominas();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDeNumeroDeSeguro
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                NumeroAsegurado = dataRow.Field<string>("NUMEROASEGURADO")


            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDeNumeroDeSeguro(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODENUMERODESEGURO",
                    IdTipoAP = 2009,
                    IdEmpleado = accion.IdEmpleado,
                    NumeroAsegurado = accion.NumeroAsegurado,
                    FechaRige = accion.FechaRige,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDePuesto(int id)
        {
            ViewBag.Departamento = Departamentos();
            ViewBag.Puesto = Puestos();
            ViewBag.Nomina = Nominas();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDePuesto
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdDepartamento = dataRow.Field<string>("DEPARTAMENTO"),
                IdPuesto = dataRow.Field<string>("PUESTO"),
                IdNomina = dataRow.Field<string>("NOMINA"),
                SalarioReferencia = dataRow.Field<decimal>("SALARIOREFERENCIA")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDePuesto(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODEPUESTO",
                    IdTipoAP = 2010,
                    IdEmpleado = accion.IdEmpleado,
                    IdDepartamento = accion.IdDepartamento,
                    IdPuesto = accion.IdPuesto,
                    IdNomina = accion.IdNomina,
                    FechaRige = accion.FechaRige,
                    SalarioReferencia = accion.SalarioReferencia,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDePorcentajeDeAhorros(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDePorcentajeDeAhorro
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                AhorroAsociacion = dataRow.Field<decimal>("AHORROASOCIACION")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDePorcentajeDeAhorros(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODEPUESTO",
                    IdTipoAP = 2011,
                    IdEmpleado = accion.IdEmpleado,
                    AhorroAsociacion = accion.AhorroAsociacion,
                    FechaRige = accion.FechaRige,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDeRegimenVacacional(int id)
        {
            ViewBag.RegimenVacacional = ControlVacacional();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDeRegimenVacacional
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdRegimenVacacional = dataRow.Field<string>("CONTROLVACACIONAL"),
                CorreoElectronico = dataRow.Field<string>("CORREOELECTRONICO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDeRegimenVacacional(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODEREGIMENVACACIONAL",
                    IdTipoAP = 2012,
                    IdEmpleado = accion.IdEmpleado,
                    IdRegimenVacacional = accion.IdRegimenVacacional,
                    CorreoElectronico = accion.CorreoElectronico,
                    FechaRige = accion.FechaRige,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APCambioDeSalario(int id)
        {
            ViewBag.FormaPago = FormaPago();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APCambioDeSalario
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                IdFormaPago = dataRow.Field<string>("FORMAPAGO"),
                SalarioReferencia = dataRow.Field<decimal>("SALARIOREFERENCIA"),

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APCambioDeSalario(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APCAMBIODESALARIO",
                    IdTipoAP = 2013,
                    IdEmpleado = accion.IdEmpleado,
                    IdFormaPago = accion.IdFormaPago,
                    SalarioReferencia = accion.SalarioReferencia,
                    FechaRige = accion.FechaRige,
                    ObservacionesAP = accion.ObservacionesAP,
                    FechaVence = DateTime.Now,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APDiasPagadosDeMas(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APDiasPagadosDeMas
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APDiasPagadosDeMas(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APDIASPAGADOSDEMAS",
                    IdTipoAP = 2015,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APIncapacidadINS(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APIncapacidad
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APIncapacidadINS(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APINCAPACIDAD",
                    IdTipoAP = 2016,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APIncapacidadMaternidad(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APIncapacidad
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APIncapacidadMaternidad(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APINCAPACIDAD",
                    IdTipoAP = 2017,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APIncapacidadCCSS(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APIncapacidad
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APIncapacidadCCSS(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APINCAPACIDAD",
                    IdTipoAP = 2019,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APLiquidacionPorAbandono(int id)
        {
            ViewBag.RegimenVacacional = ControlVacacional();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APLiquidacion
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APLiquidacionPorAbandono(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APLIQUIDACIONES",
                    IdTipoAP = 2027,
                    IdEmpleado = accion.IdEmpleado,
                    EstadoAP = "PENDIENTE",
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APLiquidacionPorDespidoConResponsabilidad(int id)
        {
            ViewBag.RegimenVacacional = ControlVacacional();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APLiquidacion
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APLiquidacionPorDespidoConResponsabilidad(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APLIQUIDACIONES",
                    IdTipoAP = 2028,
                    IdEmpleado = accion.IdEmpleado,
                    EstadoAP = "PENDIENTE",
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APLiquidacionPorDespidoSinResponsabilidad(int id)
        {
            ViewBag.RegimenVacacional = ControlVacacional();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APLiquidacion
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APLiquidacionPorDespidoSinResponsabilidad(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APLIQUIDACIONES",
                    IdTipoAP = 2029,
                    IdEmpleado = accion.IdEmpleado,
                    EstadoAP = "PENDIENTE",
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APLiquidacionPorPension(int id)
        {
            ViewBag.RegimenVacacional = ControlVacacional();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APLiquidacion
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APLiquidacionPorPension(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APLIQUIDACIONES",
                    IdTipoAP = 2030,
                    IdEmpleado = accion.IdEmpleado,
                    EstadoAP = "PENDIENTE",
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APLiquidacionPorRenuncia(int id)
        {
            ViewBag.RegimenVacacional = ControlVacacional();

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APLiquidacion
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APLiquidacionPorRenuncia(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APLIQUIDACIONES",
                    IdTipoAP = 2031,
                    IdEmpleado = accion.IdEmpleado,
                    EstadoAP = "PENDIENTE",
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APPermisoConGoceDeSalario(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APPermisosConYSinGoceDeSalario
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APPermisoConGoceDeSalario(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APPERMISOSCONYSINGOCEDESALARIO",
                    IdTipoAP = 2020,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APPermisoSinGoceDeSalario(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APPermisosConYSinGoceDeSalario
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APPermisoSinGoceDeSalario(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APPERMISOSCONYSINGOCEDESALARIO",
                    IdTipoAP = 2022,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APSuspencion(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APSuspencion
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APSuspencion(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APPERMISOSCONYSINGOCEDESALARIO",
                    IdTipoAP = 2023,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APVacacionesDisfrutadas(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APVacaccionesDisfrutadasYAcumuladas
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                SaldoVacaciones = dataRow.Field<int>("VACACIONESPENDIENTES")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APVacacionesDisfrutadas(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APVACACIONESDISFRUTADASYACUMULADAS",
                    IdTipoAP = 2024,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    SaldoVacaciones = accion.SaldoVacaciones,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APVacacionesAcumuladas(int id)
        {

            var dt = _servicio.ConsultarEmpleado(new Empleado
            {
                Accion = "CONSULTAR",
                IdEmpleado = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                FechaIngreso = DateTime.Now,
                FechaSalida = DateTime.Now,
                UltimoCambioVac = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.APVacaccionesDisfrutadasYAcumuladas
            {

                IdEmpleado = dataRow.Field<int>("IDEMPLEADO"),
                SaldoVacaciones = dataRow.Field<int>("VACACIONESPENDIENTES")

            }).FirstOrDefault();

            return View(usr);
        }

        // POST: AccionesDePersonal/Edit/5
        [HttpPost]
        public ActionResult APVacacionesAcumuladas(AccionDePersonal accion)
        {
            try
            {
                var objeto = new AccionDePersonal
                {
                    Accion = "APVACACIONESDISFRUTADASYACUMULADAS",
                    IdTipoAP = 2026,
                    IdEmpleado = accion.IdEmpleado,
                    DiasAP = accion.DiasAP,
                    SaldoVacaciones = accion.SaldoVacaciones,
                    FechaRige = accion.FechaRige,
                    FechaVence = accion.FechaVence,
                    ObservacionesAP = accion.ObservacionesAP,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                    FechaAprobacion = DateTime.Now,
                    FechaAplicacion = DateTime.Now,
                    FechaCancelacion = DateTime.Now,
                    FechaDenegacion = DateTime.Now,
                    FechaNacimiento = DateTime.Now,
                    UltimoCambioVacacional = DateTime.Now
                };

                var dt = _servicio.ProcesarAccionDePersonal(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index", "Empleados");
                }
                else
                {
                    return View("Index", "Empleados");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: AccionesDePersonal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccionesDePersonal/Delete/5
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
