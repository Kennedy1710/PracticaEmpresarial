using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    public class NominasController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Nominas
        [Authorize]
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarNomina(new Nomina {Accion = "CONSULTAR", FechaCreacion = DateTime.Now, 
                FechaModificacion = DateTime.Now});

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Nomina
            {
                IdNomina = dataRow.Field<int>("IDNOMINA"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                TipoNomina = dataRow.Field<string>("TIPONOMINA"),
                Consecutivo = dataRow.Field<int>("CONSECUTIVO"),
                Estado = dataRow.Field<string>("ESTADO")

            }).ToList();

            return View(usr);
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nominas/Create
        [HttpPost]
        public ActionResult Create(Nomina nomina)
        {
            try
            {
                var objeto = new Nomina
                {
                    Accion = "INSERTAR",
                    Alias = nomina.Alias,
                    Descripcion = nomina.Descripcion,
                    TipoNomina = nomina.TipoNomina,
                    Consecutivo = nomina.Consecutivo,
                    Estado = "Activo",
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarNomina(objeto);

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

        // GET: Nominas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nominas/Edit/5
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

        // GET: Nominas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nominas/Delete/5
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
