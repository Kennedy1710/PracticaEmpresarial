using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISASEPBA.ServicioAsepba;


namespace SISASEPBA.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Departamentos
        [Authorize]
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarDepartamentos(new Departamento { Accion = "CONSULTAR", FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now});

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Departamento
            {
                IdDepartamento = dataRow.Field<int>("IDDEPARTAMENTO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<bool>("ESTADO"),
                
            }).ToList();

            return View(usr);
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        [HttpPost]
        public ActionResult Create(Models.Departamento departamento)
        {
            var objeto = new Departamento
            {
                Accion = "INSERTAR",
                Alias = departamento.Alias,
                Descripcion = departamento.Descripcion,
                Estado = departamento.Estado,
                UsuarioCreacion = User.Identity.Name,
                FechaCreacion = DateTime.Now,
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
                return View("Create");
            }
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int id)
        {
            var dt = _servicio.ConsultarDepartamentos(new Departamento {Accion = "CONSULTAR_DEPARTAMENTO", IdDepartamento = id, 
                FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now});

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Departamento
            {
                IdDepartamento = dataRow.Field<int>("IDDEPARTAMENTO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
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

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departamentos/Delete/5
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
