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
    public class DocumentosController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();

        // GET: Documentos
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarDocumentos(new Documentos
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaRige = DateTime.Now,
                FechaVence = DateTime.Now,

            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Documentos
            {
                IdDocumento = dataRow.Field<int>("IDDOCUMENTO"),
                IdTipoDocumento = dataRow.Field<int>("IDTIPODOCUMENTO"),
                TituloDocumento = dataRow.Field<string>("TITULODOCUMENTO"),
                Descripcion = dataRow.Field<string>("DESCRIPCION")
            }).ToList();
            return View(usr);
        }

        //listar tipo de documentos
        public List<Models.TipoDocumento> GetTipoDocumento()
        {
            var dt = _servicio.ConsultarTipoDocumento(new TipoDocumento
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now

            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.TipoDocumento
            {
                IdTipoDocumento = dataRow.Field<int>("IDTIPODOCUMENTO"),
                Alias = dataRow.Field<string>("ALIAS"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Estado = dataRow.Field<bool>("ESTADO")
            }).ToList();

            return list;
        }

        // GET: Documentos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Documentos/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumento = GetTipoDocumento();
            return View();
        }

        // POST: Documentos/Create
        [HttpPost]
        public ActionResult Create(Documentos documentos, HttpPostedFileBase doc)
        {

            if (doc != null && doc.ContentLength > 0)
            {
                byte[] documentoData = null;
                using (var documento = new BinaryReader(doc.InputStream))
                {
                    documentoData = documento.ReadBytes(doc.ContentLength);
                }

                documentos.DocumentoAdjunto = documentoData;
            }
            try
            {
                var objeto = new Documentos
                {
                    Accion = "INSERTAR",
                    IdTipoDocumento = documentos.IdTipoDocumento,
                    TituloDocumento = documentos.TituloDocumento,
                    Descripcion = documentos.Descripcion,
                    FechaRige = documentos.FechaRige,
                    FechaVence = documentos.FechaVence,
                    Estado = documentos.Estado,
                    DocumentoAdjunto = documentos.DocumentoAdjunto,
                    IdRenovacion = documentos.IdRenovacion,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarDocumentos(objeto);

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


        // GET: Documentos/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TipoDocumento = GetTipoDocumento();

            var dt = _servicio.ConsultarDocumentos(new Documentos
            {
                Accion = "CONSULTAR_DOC",
                IdDocumento = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaRige = DateTime.Now,
                FechaVence = DateTime.Now

            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Documentos
            {
                IdDocumento = dataRow.Field<int>("IDDOCUMENTO"),
                IdTipoDocumento = dataRow.Field<int>("IDTIPODOCUMENTO"),
                TituloDocumento = dataRow.Field<string>("TITULODOCUMENTO"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                FechaRige = dataRow.Field<DateTime>("FECHARIGE"),
                FechaVence = dataRow.Field<DateTime>("FECHAVENCE"),
                Estado = dataRow.Field<string>("ESTADO"),
                DocumentoAdjunto = dataRow.Field<byte[]>("DOCUMENTOADJUNTO"),
                IdRenovacion = dataRow.Field<int>("IDRENOVACION"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")


            }).FirstOrDefault();

            return View(usr);

        }

        // POST: Documentos/Edit/5
        [HttpPost]
        public ActionResult Edit(Documentos documentos, HttpPostedFileBase doc)
        {
            if (doc != null && doc.ContentLength > 0)
            {
                byte[] documentoData = null;
                using (var documento = new BinaryReader(doc.InputStream))
                {
                    documentoData = documento.ReadBytes(doc.ContentLength);
                }

                documentos.DocumentoAdjunto = documentoData;
            }


            try
            {
                var objeto = new Documentos
                {
                    Accion = "ACTUALIZAR",
                    IdDocumento = documentos.IdDocumento,
                    IdTipoDocumento = documentos.IdTipoDocumento,
                    TituloDocumento = documentos.TituloDocumento,
                    Descripcion = documentos.Descripcion,
                    FechaRige = documentos.FechaRige,
                    FechaVence = documentos.FechaVence,
                    Estado = documentos.Estado,
                    DocumentoAdjunto = documentos.DocumentoAdjunto,
                    IdRenovacion = documentos.IdRenovacion,
                    UsuarioCreacion = documentos.UsuarioCreacion,
                    FechaCreacion = documentos.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarDocumentos(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch
            {
                return View();
            }

        }
        // GET: Documentos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Documentos/Delete/5
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
