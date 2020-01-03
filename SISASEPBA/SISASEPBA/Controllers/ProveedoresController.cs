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
    public class ProveedoresController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Proveedores
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarProveedor(new Proveedor
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaRige = DateTime.Now,
                FechaVence = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Proveedor
            {
                IdProveedor = dataRow.Field<int>("IDPROVEEDOR"),
                NombreReal = dataRow.Field<string>("NOMBREREAL"),
                FechaRige = dataRow.Field<DateTime>("FECHARIGE"),
                FechaVence = dataRow.Field<DateTime>("FECHAVENCE"),
                Estado = dataRow.Field<bool>("ESTADO"),

            }).ToList();
            return View(usr);
        }


        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        public ActionResult Create(Proveedor proveedor, HttpPostedFileBase doc, HttpPostedFileBase img)
        {
            try
            {
                if (doc != null && doc.ContentLength > 0)
                {
                    byte[] documentoData = null;
                    using (var documento = new BinaryReader(doc.InputStream))
                    {
                        documentoData = documento.ReadBytes(doc.ContentLength);
                    }

                    proveedor.DocumentoAdjunto = documentoData;
                }

                if (img != null && img.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var imagen = new BinaryReader(img.InputStream))
                    {
                        imageData = imagen.ReadBytes(img.ContentLength);
                    }

                    proveedor.Logo = imageData;
                }

                var objeto = new Proveedor
                {
                    Accion = "INSERTAR",
                    NumeroCedula = proveedor.NumeroCedula,
                    NombreFantasia = proveedor.NombreFantasia,
                    NombreReal = proveedor.NombreReal,
                    PrimerNombreApoderado = proveedor.PrimerNombreApoderado,
                    SegundoNombreApoderado = proveedor.SegundoNombreApoderado,
                    PrimerApellidoApoderado = proveedor.PrimerApellidoApoderado,
                    SegundoApellidoApoderado = proveedor.SegundoApellidoApoderado,
                    CedulaApoderado = proveedor.CedulaApoderado,
                    FechaRige = proveedor.FechaRige,
                    FechaVence = proveedor.FechaVence,
                    Estado = proveedor.Estado,
                    DescripcionConvenio = proveedor.DescripcionConvenio,
                    BeneficioAsociado = proveedor.BeneficioAsociado,
                    BeneficioASEPBA = proveedor.BeneficioASEPBA,
                    DocumentoAdjunto = proveedor.DocumentoAdjunto,
                    PersonaContacto = proveedor.PersonaContacto,
                    CorreoContacto = proveedor.CorreoContacto,
                    TelefonoContacto = proveedor.TelefonoContacto,
                    SegundaPersonaContacto = proveedor.SegundaPersonaContacto,
                    CorreoSegundoContacto = proveedor.CorreoSegundoContacto,
                    TelefonoSegundoContacto = proveedor.TelefonoSegundoContacto,
                    Logo = proveedor.Logo,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarProveedor(objeto);

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

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int id)
        {
            var dt = _servicio.ConsultarProveedor(new Proveedor
            {
                Accion = "CONSULTAR_PROVEEDOR",
                IdProveedor = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaRige = DateTime.Now,
                FechaVence = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Proveedor
            {
                IdProveedor = dataRow.Field<int>("IDPROVEEDOR"),
                NumeroCedula = dataRow.Field<int>("NUMEROCEDULA"),
                NombreFantasia = dataRow.Field<string>("NOMBREFANTASIA"),
                NombreReal = dataRow.Field<string>("NOMBREREAL"),
                PrimerNombreApoderado = dataRow.Field<string>("PRIMERNOMBREAPODERADO"),
                SegundoNombreApoderado = dataRow.Field<string>("SEGUNDONOMBREAPODERADO"),
                PrimerApellidoApoderado = dataRow.Field<string>("PRIMERAPELLIDOAPODERADO"),
                SegundoApellidoApoderado = dataRow.Field<string>("SEGUNDOAPELLIDOAPODERADO"),
                CedulaApoderado = dataRow.Field<int>("CEDULAAPODERADO"),
                FechaRige = dataRow.Field<DateTime>("FECHARIGE"),
                FechaVence = dataRow.Field<DateTime>("FECHAVENCE"),
                Estado = dataRow.Field<bool>("ESTADO"),
                DescripcionConvenio = dataRow.Field<string>("DESCRIPCIONCONVENIO"),
                BeneficioAsociado = dataRow.Field<string>("BENEFICIOASOCIADO"),
                BeneficioASEPBA = dataRow.Field<string>("BENEFICIOASEPBA"),
                DocumentoAdjunto = dataRow.Field < byte[] >("DOCUMENTOADJUNTO"),
                PersonaContacto = dataRow.Field<string>("PERSONACONTACTO"),
                CorreoContacto = dataRow.Field<string>("CORREOCONTACTO"),
                TelefonoContacto = dataRow.Field<string>("TELEFONOCONTACTO"),
                SegundaPersonaContacto = dataRow.Field<string>("SEGUNDAPERSONACONTACTO"),
                CorreoSegundoContacto = dataRow.Field<string>("CORREOSEGUNDOCONTACTO"),
                TelefonoSegundoContacto = dataRow.Field<string>("TELEFONOSEGUNDOCONTACTO"),
                Logo = dataRow.Field<byte[]>("LOGO"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")

            }).FirstOrDefault();
            return View(usr);
        }

        // POST: Proveedores/Edit/5
        [HttpPost]
        public ActionResult Edit(Proveedor proveedor, HttpPostedFileBase doc, HttpPostedFileBase img)
        {
            try
            {
                if (doc != null && doc.ContentLength > 0)
                {
                    byte[] documentoData = null;
                    using (var documento = new BinaryReader(doc.InputStream))
                    {
                        documentoData = documento.ReadBytes(doc.ContentLength);
                    }

                    proveedor.DocumentoAdjunto = documentoData;
                }

                if (img != null && img.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var imagen = new BinaryReader(img.InputStream))
                    {
                        imageData = imagen.ReadBytes(img.ContentLength);
                    }

                    proveedor.Logo = imageData;
                }

                var objeto = new Proveedor
                {
                    Accion = "ACTUALIZAR",
                    IdProveedor = proveedor.IdProveedor,
                    NumeroCedula = proveedor.NumeroCedula,
                    NombreFantasia = proveedor.NombreFantasia,
                    NombreReal = proveedor.NombreReal,
                    PrimerNombreApoderado = proveedor.PrimerNombreApoderado,
                    SegundoNombreApoderado = proveedor.SegundoNombreApoderado,
                    PrimerApellidoApoderado = proveedor.PrimerApellidoApoderado,
                    SegundoApellidoApoderado = proveedor.SegundoApellidoApoderado,
                    CedulaApoderado = proveedor.CedulaApoderado,
                    FechaRige = proveedor.FechaRige,
                    FechaVence = proveedor.FechaVence,
                    Estado = proveedor.Estado,
                    DescripcionConvenio = proveedor.DescripcionConvenio,
                    BeneficioAsociado = proveedor.BeneficioAsociado,
                    BeneficioASEPBA = proveedor.BeneficioASEPBA,
                    DocumentoAdjunto = proveedor.DocumentoAdjunto,
                    PersonaContacto = proveedor.PersonaContacto,
                    CorreoContacto = proveedor.CorreoContacto,
                    TelefonoContacto = proveedor.TelefonoContacto,
                    SegundaPersonaContacto = proveedor.SegundaPersonaContacto,
                    CorreoSegundoContacto = proveedor.CorreoSegundoContacto,
                    TelefonoSegundoContacto = proveedor.TelefonoSegundoContacto,
                    Logo = proveedor.Logo,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarProveedor(objeto);

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
