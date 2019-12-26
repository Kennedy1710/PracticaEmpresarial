using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    public class CapacitacionesController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Capacitaciones
        public ActionResult Index()
        {

            var dt = _servicio.ConsultarCapacitacion(new Capacitacion
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });


            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Puesto
            {
                IdPuesto = dataRow.Field<int>("IDPUESTO"),
                IdDepartamento = dataRow.Field<string>("DEPARTAMENTO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<bool>("ESTADO"),

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
            return View();
        }

        // POST: Capacitaciones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
