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
    public class CartasController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Cartas
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarCartas(new Cartas
            {
                Accion = "CONSULTAR",
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Cartas
            {
                IdCarta = dataRow.Field<int>("IDCARTA"),
                IdSocio = dataRow.Field<string>("SOCIO"),
                IdProveedor = dataRow.Field<string>("PROVEEDOR"),
                Fecha = dataRow.Field<DateTime>("FECHA"),
            }).ToList();

            return View(usr);
        }

        public List<Models.Socio> GetSocio()
        {
            var dt = _servicio.ConsultarSocio(new Socios
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaIngresoAsociacion = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Socio
            {
                IdSocio = dataRow.Field<int>("IDSOCIO"),
                NumeroIdentificacion = dataRow.Field<int>("NUMEROIDENTIFICACION"),
                Empresa = dataRow.Field<string>("EMPRESA"),
                FechaIngresoAsociacion = dataRow.Field<DateTime>("FECHAINGRESOASOCIACION"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();

            return list;
        }

        public List<Models.Proveedor> GetProveedor()
        {
            var dt = _servicio.ConsultarProveedor(new Proveedor
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaRige = DateTime.Now,
                FechaVence = DateTime.Now
            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Proveedor
            {
                IdProveedor = dataRow.Field<int>("IDPROVEEDOR"),
                NombreReal = dataRow.Field<string>("NOMBREREAL"),
                FechaRige = dataRow.Field<DateTime>("FECHARIGE"),
                FechaVence = dataRow.Field<DateTime>("FECHAVENCE"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();

            return list;
        }

        // GET: Cartas/Create
        public ActionResult Create()
        {
            ViewBag.Socios = GetSocio();
            ViewBag.Proveedor = GetProveedor();
            return View();
        }

        // POST: Cartas/Create
        [HttpPost]
        public ActionResult Create(Cartas cartas)
        {
            try
            {
                var objeto = new Cartas
                {
                    Accion = "INSERTAR",
                    IdSocio = cartas.IdSocio,
                    IdProveedor = cartas.IdProveedor,
                    Fecha = cartas.Fecha,
                    CantidadImpresiones = cartas.CantidadImpresiones,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };
                var dt = _servicio.ProcesarCartas(objeto);

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

        // GET: Cartas/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Socios = GetSocio();
            ViewBag.Proveedor = GetProveedor();

            var dt = _servicio.ConsultarCartas(new Cartas
            {
                Accion = "CONSULTAR_CARTA",
                IdCarta = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Fecha = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Cartas
            {
                IdCarta = dataRow.Field<int>("IDCARTA"),
                IdSocio = dataRow.Field<string>("SOCIO"),
                IdProveedor = dataRow.Field<string>("PROVEEDOR"),
                Fecha = dataRow.Field<DateTime>("FECHA"),
                CantidadImpresiones = dataRow.Field<int>("CANTIDADIMPRESIONES"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")

            }).FirstOrDefault();
            return View(usr);
        }

        // POST: Cartas/Edit/5
        [HttpPost]
        public ActionResult Edit(Cartas cartas)
        {
            try
            {
                var objeto = new Cartas
                {
                    Accion = "ACTUALIZAR",
                    IdCarta = cartas.IdCarta,
                    IdSocio = cartas.IdSocio,
                    IdProveedor = cartas.IdProveedor,
                    Fecha = cartas.Fecha,
                    CantidadImpresiones = cartas.CantidadImpresiones,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };
                var dt = _servicio.ProcesarCartas(objeto);

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
