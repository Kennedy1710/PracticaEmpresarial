using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SISASEPBA.ServicioAsepba;
using System.IO;

namespace SISASEPBA.Controllers
{
    public class CapacitacionesController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Capacitaciones

        public List<Models.TipoCapacitaciones> TipoCapacitaciones()
        {
            var dt = _servicio.ConsultarTipoCapacitacion(new TipoCapacitacion
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.TipoCapacitaciones
            {
                IdTipoCapacitacion = dataRow.Field<int>("IDTIPOCAPACITACION"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<string>("ESTADO"),

            }).ToList();

            return list;
        }

        public ActionResult Index()
        {

            var dt = _servicio.ConsultarCapacitacion(new Capacitacion
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaInicio = DateTime.Now,
                FechaRegistro = DateTime.Now,
                FechaFinalizacion = DateTime.Now
                
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Capacitacion
            {
                IdCapacitacionEmpleado = dataRow.Field<int>("IDCAPACITACIONEMPLEADO"),
                IdTipoCapacitacion = dataRow.Field<string>("TIPOCAPACITACION"),
                EmpresaCapacitadora = dataRow.Field<string>("EMPRESACAPACITADORA"),
                NombreCapacitacion = dataRow.Field<string>("NOMBRECAPACITACION"),
                Estado = dataRow.Field<string>("ESTADO")

            }).ToList();

            return View(usr);
        }

        // GET: Capacitaciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Capacitaciones/Create
        public ActionResult Create()
        {
            ViewBag.TipoCapacitacion = TipoCapacitaciones();

            return View();
        }

        // POST: Capacitaciones/Create
        [HttpPost]
        public ActionResult Create(Capacitacion capacitacion, HttpPostedFileBase doc)
        {

            if (doc != null && doc.ContentLength > 0)
            {
                byte[] file = null;
                using (var archivo = new BinaryReader(doc.InputStream))
                {
                    file = archivo.ReadBytes(doc.ContentLength);
                }

                capacitacion.DocumentoAdjunto = file;
            }

            try
            {
                var objeto = new Capacitacion
                {
                    Accion = "INSERTAR",
                    IdTipoCapacitacion = capacitacion.IdTipoCapacitacion,
                    FechaRegistro = capacitacion.FechaRegistro,
                    FechaInicio = capacitacion.FechaInicio,
                    FechaFinalizacion = capacitacion.FechaFinalizacion,
                    CantidadHoras = capacitacion.CantidadHoras,
                    NombreCapacitacion = capacitacion.NombreCapacitacion,
                    Descripcion = capacitacion.Descripcion,
                    PrimerNombreDelCapacitador = capacitacion.PrimerNombreDelCapacitador,
                    SegundoNombreDelCapacitador = capacitacion.SegundoNombreDelCapacitador,
                    PrimerApellidoDelCapacitador = capacitacion.PrimerApellidoDelCapacitador,
                    SegundoApellidoDelCapacitador = capacitacion.SegundoApellidoDelCapacitador,
                    EmpresaCapacitadora = capacitacion.EmpresaCapacitadora,
                    Origen = capacitacion.Origen,
                    CargoPagoCapacitacion = capacitacion.CargoPagoCapacitacion,
                    Estado = "PLANEADA",
                    DocumentoAdjunto = capacitacion.DocumentoAdjunto,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarCapacitacion(objeto);

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

        // GET: Capacitaciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Capacitaciones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Capacitaciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Capacitaciones/Delete/5
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
