using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    public class PuestosController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Puestos
        [Authorize]
        public ActionResult Index()
        {

            var dt = _servicio.ConsultarPuestos(new Puesto { Accion = "CONSULTAR", FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now });


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

        // GET: Puestos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public List<Models.Departamento> GetDepartamentos() {
            var dt = _servicio.ConsultarDepartamentos(new Departamento { 
                Accion="CONSULTAR",FechaCreacion=DateTime.Now,FechaModificacion=DateTime.Now });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Departamento
            {
                IdDepartamento = dataRow.Field<int>("IDDEPARTAMENTO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();

            return list;
        }
        // GET: Puestos/Create
        public ActionResult Create()
        {
            ViewBag.ListaDepartamentos = GetDepartamentos();
            return View();
        }

        // POST: Puestos/Create
        [HttpPost]
        public ActionResult Create(Puesto puesto)
        {

            try
            {
                var objeto = new Puesto
            {
                Accion = "INSERTAR",
                IdDepartamento = puesto.IdDepartamento,
                Alias = puesto.Alias,
                Descripcion = puesto.Descripcion,
                Estado = puesto.Estado,
                UsuarioCreacion = User.Identity.Name,
                FechaCreacion = DateTime.Now,
                UsuarioModificacion = User.Identity.Name,
                FechaModificacion = DateTime.Now
            };

            var dt = _servicio.ProcesarPuestos(objeto);

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

        // GET: Puestos/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Departamento = Departamentos();

            var dt = _servicio.ConsultarPuestos(new Puesto
            {
                Accion = "CONSULTAR_PUESTO",
                IdPuesto = id,
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
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION"),
                
            }).FirstOrDefault();

            return View(usr);
        }

        // POST: Puestos/Edit/5
        [HttpPost]
        public ActionResult Edit(Puesto puesto)
        {
            try
            {
                var objeto = new Puesto
                {
                    Accion = "ACTUALIZAR",
                    IdPuesto = puesto.IdPuesto,
                    IdDepartamento = puesto.IdDepartamento,
                    Alias = puesto.Alias,
                    Descripcion = puesto.Descripcion,
                    Estado = puesto.Estado,
                    UsuarioCreacion = puesto.UsuarioCreacion,
                    FechaCreacion = puesto.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarPuestos(objeto);
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

        // GET: Puestos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Puestos/Delete/5
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
