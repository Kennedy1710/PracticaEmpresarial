using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Usuarios
        [Authorize]
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarUsuarios(new Usuario {Accion = "C",UsuarioSesion = User.Identity.Name});

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Usuario
            {
                CodUsuario = dataRow.Field<string>("USUARIO"),
                Nombre = dataRow.Field<string>("NOMBRE"),
                Correo = dataRow.Field<string>("CORREOELECTRONICO"),
                Empresa = dataRow.Field<string>("EMPRESA"),
                Estado = dataRow.Field<string>("ESTADO")
            }).ToList();
            return View(usr);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Models.Usuario o)
        {
            try
            {
                var obj = new Usuario
                {
                    Accion = "I",
                    CodUsuario = o.CodUsuario,
                    Nombre = o.Nombre,
                    Correo = o.Correo,
                    EsEmpleado = o.EsEmpleado,
                    Contrasena = o.Contrasena,
                    Empresa = o.Empresa,
                    ContrasenaVence = o.ContrasenaVence,
                    CodEmpleado = o.CodEmpleado,
                    DiasVencimiento = o.DiasVencimiento,
                    MaximoIntentos = o.MaximoIntentos,
                    CambioProximoInicio = o.CambioProximoInicio,
                    UsuarioSesion = User.Identity.Name
                };

                var dt = _servicio.ProcesarUsuarios(obj);
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

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            var dt = _servicio.ConsultarUsuarios(new Usuario { Accion = "CU", CodUsuario = id, UsuarioSesion = User.Identity.Name });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Usuario
            {
                CodUsuario = dataRow.Field<string>("USUARIO"),
                Nombre = dataRow.Field<string>("NOMBRE"),
                Correo = dataRow.Field<string>("CORREOELECTRONICO"),
                Empresa = dataRow.Field<string>("EMPRESA"),
                Estado = dataRow.Field<string>("ESTADO"),
                EsEmpleado = dataRow.Field<bool>("ES_EMPLEADO"),
                Contrasena = dataRow.Field<string>("CONTRASEÑA"),
                //con = dataRow.Field<string>("CONTRASEÑA"),
                ContrasenaVence = dataRow.Field<bool>("CONTRASEÑAVENCE"),
                CodEmpleado = dataRow.Field<string>("CODIGOEMPLEADO"),
                DiasVencimiento = dataRow.Field<int>("DIASVENCIMIENTO"),
                MaximoIntentos = dataRow.Field<int>("MAXIMOINTENTOS"),
                CambioProximoInicio = dataRow.Field<bool>("CAMBIOPROXIMOINICIO")
            }).FirstOrDefault();

            return View(usr);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Usuario o)
        {
            try
            {
                var obj = new Usuario
                {
                    Accion = "U",
                    CodUsuario = o.CodUsuario,
                    Nombre = o.Nombre,
                    Correo = o.Correo,
                    Empresa = o.Empresa,
                    Estado = o.Estado,
                    EsEmpleado = o.EsEmpleado,
                    Contrasena = o.Contrasena,
                    ContrasenaVence = o.ContrasenaVence,
                    CodEmpleado = o.CodEmpleado,
                    DiasVencimiento = o.DiasVencimiento,
                    MaximoIntentos = o.MaximoIntentos,
                    CambioProximoInicio = o.CambioProximoInicio,
                    UsuarioSesion = User.Identity.Name
                };

                var dt = _servicio.ProcesarUsuarios(obj);
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

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
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
