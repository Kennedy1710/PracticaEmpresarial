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
    public class OrdenesDeCompraController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: OrdenesDeCompra
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarOrdenCompra(new OrdenCompra
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaEmision = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.OrdenDeCompra
            {
                IdOrdenCompra = dataRow.Field<int>("IDORDENCOMPRA"),
                IdSocio = dataRow.Field<string>("SOCIO"),
                IdProveedor = dataRow.Field<string>("PROVEEDOR"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                NumeroFacturaProforma = dataRow.Field<int>("NUMEROFACTURAPROFORMA"),

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

        // GET: OrdenesDeCompra/Create
        public ActionResult Create()
        {
            ViewBag.Socios = GetSocio();
            ViewBag.Proveedor = GetProveedor();
            return View();
        }

        // POST: OrdenesDeCompra/Create
        [HttpPost]
        public ActionResult Create(OrdenCompra ordenCompra)
        {
            try
            {
                var objeto = new OrdenCompra
                {
                    Accion = "INSERTAR",
                    IdSocio = ordenCompra.IdSocio,
                    IdProveedor = ordenCompra.IdProveedor,
                    FechaEmision = ordenCompra.FechaEmision,
                    Descripcion = ordenCompra.Descripcion,
                    MontoTotal = ordenCompra.MontoTotal,
                    NumeroFacturaProforma = ordenCompra.NumeroFacturaProforma,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarOrdenCompra(objeto);

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

        // GET: OrdenesDeCompra/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Socios = GetSocio();
            ViewBag.Proveedor = GetProveedor();

            var dt = _servicio.ConsultarOrdenCompra(new OrdenCompra
            {
                Accion = "CONSULTAR_ORDEN_COMPRA",
                IdOrdenCompra = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaEmision = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.OrdenDeCompra
            {
                IdOrdenCompra = dataRow.Field<int>("IDORDENCOMPRA"),
                IdSocio = dataRow.Field<string>("SOCIO"),
                IdProveedor = dataRow.Field<string>("PROVEEDOR"),
                FechaEmision = dataRow.Field<DateTime>("FECHAEMISION"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                MontoTotal = dataRow.Field<int>("MONTOTOTAL"),
                NumeroFacturaProforma = dataRow.Field<int>("NUMEROFACTURAPROFORMA"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")

            }).FirstOrDefault();
            return View(usr);
        }

        // POST: OrdenesDeCompra/Edit/5
        [HttpPost]
        public ActionResult Edit(OrdenCompra ordenCompra)
        {
            try
            {
                var objeto = new OrdenCompra
                {
                    Accion = "ACTUALIZAR",
                    IdOrdenCompra = ordenCompra.IdOrdenCompra,
                    IdSocio = ordenCompra.IdSocio,
                    IdProveedor = ordenCompra.IdProveedor,
                    FechaEmision = ordenCompra.FechaEmision,
                    Descripcion = ordenCompra.Descripcion,
                    MontoTotal = ordenCompra.MontoTotal,
                    NumeroFacturaProforma = ordenCompra.NumeroFacturaProforma,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now,
                };

                var dt = _servicio.ProcesarOrdenCompra(objeto);

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
