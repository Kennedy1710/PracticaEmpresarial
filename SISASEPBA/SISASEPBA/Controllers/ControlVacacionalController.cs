using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    public class ControlVacacionalController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();

        [Authorize]
        // GET: ControlVacacional
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarControlVacacional(new ControlVacacional {Accion = "CONSULTAR", FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.ControlVacacional
            {
                IdRegimenVacacional = dataRow.Field<int>("IDREGIMENVACACIONAL"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                //IdTipoAP = dataRow.Field<string>("IDTIPOAP"),
                Estado = dataRow.Field<bool>("ESTADO"),
                DiasAcuMes = dataRow.Field<int>("DIASACUMES"),
                DiasRestados = dataRow.Field<int>("DIASRESTADOS"),
                IncluirSabados = dataRow.Field<bool>("INCLUIRSABADOS"),
                IncluirDomingos = dataRow.Field<bool>("INCLUIRDOMINGOS")

            }).ToList();

            return View(usr);
        }

        // GET: ControlVacacional/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControlVacacional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControlVacacional/Create
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

        // GET: ControlVacacional/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ControlVacacional/Edit/5
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

        // GET: ControlVacacional/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControlVacacional/Delete/5
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
