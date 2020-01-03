using SISASEPBA.ServicioAsepba;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISASEPBA.Controllers
{
    public class SociosController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Socios
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarSocio(new Socios
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaIngresoAsociacion = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Socio
            {
                IdSocio = dataRow.Field<int>("IDSOCIO"),
                NumeroIdentificacion = dataRow.Field<int>("NUMEROIDENTIFICACION"),
                Empresa = dataRow.Field<string>("EMPRESA"),
                FechaIngresoAsociacion = dataRow.Field<DateTime>("FECHAINGRESOASOCIACION"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();
            return View(usr);
        }


        // GET: Socios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        [HttpPost]
        public ActionResult Create(Socios socio)
        {
            try
            {
                var objeto = new Socios
                {
                    Accion = "INSERTAR",
                    NumeroIdentificacion = socio.NumeroIdentificacion,
                    PrimerNombreSocio = socio.PrimerNombreSocio,
                    SegundoNombreSocio = socio.SegundoNombreSocio,
                    PrimerApellidoSocio = socio.PrimerApellidoSocio,
                    SegundoApellidoSocio = socio.SegundoApellidoSocio,
                    Empresa = socio.Empresa,
                    FechaIngresoAsociacion = socio.FechaIngresoAsociacion,
                    Estado = socio.Estado,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };
                var dt = _servicio.ProcesarSocio(objeto);

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

        // GET: Socios/Edit/5
        public ActionResult Edit(int id)
        {
            var dt = _servicio.ConsultarSocio(new Socios
            {
                Accion = "CONSULTAR_SOCIO",
                IdSocio = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaIngresoAsociacion = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Socio
            {
                IdSocio = dataRow.Field<int>("IDSOCIO"),
                NumeroIdentificacion = dataRow.Field<int>("NUMEROIDENTIFICACION"),
                PrimerNombreSocio = dataRow.Field<string>("PRIMERNOMBRESOCIO"),
                SegundoNombreSocio = dataRow.Field<string>("SEGUNDONOMBRESOCIO"),
                PrimerApellidoSocio = dataRow.Field<string>("PRIMERAPELLIDOSOCIO"),
                SegundoApellidoSocio = dataRow.Field<string>("SEGUNDOAPELLIDOSOCIO"),
                Empresa = dataRow.Field<string>("EMPRESA"),
                FechaIngresoAsociacion = dataRow.Field<DateTime>("FECHAINGRESOASOCIACION"),
                Estado = dataRow.Field<bool>("ESTADO"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION"),

            }).FirstOrDefault();
            return View(usr);
        }

        // POST: Socios/Edit/5
        [HttpPost]
        public ActionResult Edit(Socios socio)
        {
            try
            {
                var objeto = new Socios
                {
                    Accion = "ACTUALIZAR",
                    IdSocio = socio.IdSocio,
                    NumeroIdentificacion = socio.NumeroIdentificacion,
                    PrimerNombreSocio = socio.PrimerNombreSocio,
                    SegundoNombreSocio = socio.SegundoNombreSocio,
                    PrimerApellidoSocio = socio.PrimerApellidoSocio,
                    SegundoApellidoSocio = socio.SegundoApellidoSocio,
                    Empresa = socio.Empresa,
                    FechaIngresoAsociacion = socio.FechaIngresoAsociacion,
                    Estado = socio.Estado,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                };
                var dt = _servicio.ProcesarSocio(objeto);

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
