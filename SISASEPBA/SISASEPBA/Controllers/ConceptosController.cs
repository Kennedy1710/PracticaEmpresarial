using SISASEPBA.ServicioAsepba;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISASEPBA.Controllers
{
    public class ConceptosController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: Conceptos
        [Authorize]
        public ActionResult Index()
        {

            var dt = _servicio.ConsultarConcepto(new Conceptos
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Conceptos
            {
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                Concepto= dataRow.Field<string>("CONCEPTO"),
                TipoConcepto = dataRow.Field<string>("TIPOCONCEPTO"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Unidad = dataRow.Field<string>("UNIDAD"),

            }).ToList();
            return View(usr);
        }

        // GET: Conceptos
        [Authorize]
        public ActionResult IndexConceptoFormula()
        {

            var dt = _servicio.ConsultarConceptoFormula(new ConceptoFormula
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.ConceptoFormula
            {
                IdConceptoFormula = dataRow.Field<int>("IDCONCEPTOFORMULA"),
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                Secuencia = dataRow.Field<int>("SECUENCIA"),
                ValorInicial = dataRow.Field<int>("VALORINICIAL"),
                ValorFinal = dataRow.Field<int>("VALORFINAL"),
                NivelFormula = dataRow.Field<int>("NIVELFORMULA"),

            }).ToList();
            return View(usr);
        }
        //index Concepto liquidacion
        public ActionResult IndexConceptoLiquidacion()
        {

            var dt = _servicio.ConsultarConceptoLiquidacion(new ConceptoLiquidacion
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                FechaLiquidacion = DateTime.Now

            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.ConceptoLiquidacion
            {
                IdConceptoLiquidacion = dataRow.Field<int>("IDCONCEPTOLIQUIDACION"),
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                FechaLiquidacion = dataRow.Field<DateTime>("FECHALIQUIDACION"),
                Comentarios = dataRow.Field<string>("COMENTARIOS"),
                NumeroLiquidacion = dataRow.Field<int>("NUMEROLIQUIDACION"),

            }).ToList();
            return View(usr);
        }

        //listar concepto 
       public List<Models.Conceptos> GetConcepto()
        {
            var dt = _servicio.ConsultarConcepto(new Conceptos
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
                

            });

            var list = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Conceptos
            {
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                Concepto = dataRow.Field<string>("CONCEPTO"),
                TipoConcepto = dataRow.Field<string>("TIPOCONCEPTO"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Unidad = dataRow.Field<string>("UNIDAD"),


            }).ToList();

            return list;
        }


        // GET: Conceptos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Conceptos/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Conceptos/Create
        [HttpPost]
        public ActionResult Create(Conceptos conceptos)
        {
            try
            {
                var objeto = new Conceptos
                {
                    Accion = "INSERTAR",
                    Concepto = conceptos.Concepto,
                    TipoConcepto = conceptos.TipoConcepto,
                    Descripcion = conceptos.Descripcion,
                    Unidad = conceptos.Unidad,
                    Salarial = conceptos.Salarial,
                    Fijo = conceptos.Fijo,
                    Liquidable = conceptos.Liquidable,
                    Excluyente = conceptos.Excluyente,
                    CantidadEditable = conceptos.CantidadEditable,
                    MontoEditable = conceptos.MontoEditable,
                    UsaCantidad = conceptos.UsaCantidad,
                    UsaMonto = conceptos.UsaMonto,
                    FormulaDefinida = conceptos.FormulaDefinida,
                    ImprimeComprobante = conceptos.ImprimeComprobante,
                    ImprimeAcumulado = conceptos.ImprimeAcumulado,
                    FactorRedondeo = conceptos.FactorRedondeo,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarConcepto(objeto);

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

        //create concepto formula
        public ActionResult CreateConceptoFormula()
        {
            ViewBag.concepto = GetConcepto();

            return View();
        }

        // POST: Conceptos/Create
        [HttpPost]
        public ActionResult CreateConceptoFormula(ConceptoFormula conceptoFormula)
        {
            try
            {
                var objeto = new ConceptoFormula
                {
                    Accion = "INSERTAR",
                    IdConcepto=conceptoFormula.IdConcepto,
                    Secuencia = conceptoFormula.Secuencia,
                    ValorInicial=conceptoFormula.ValorInicial,
                    ValorFinal=conceptoFormula.ValorFinal,
                    CantidadMonto=conceptoFormula.CantidadMonto,
                    NivelFormula=conceptoFormula.NivelFormula,
                    UsaCantidad = conceptoFormula.UsaCantidad,
                    UsaMonto = conceptoFormula.UsaMonto,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarConceptoFormula(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("IndexConceptoFormula");
                }
                else
                {
                    return View("CreateConceptoFormula");
                }
            }
            catch
            {
                return View();
            }
        }

        //create concepto liquidacion
        public ActionResult CreateConceptoLiquidacion()
        {
            ViewBag.concepto = GetConcepto();
            return View();
        }

        // POST: ConceptoLiquidacion/Create
        [HttpPost]
        public ActionResult CreateConceptoLiquidacion(ConceptoLiquidacion conceptoLiquidacion)
        {
            try
            {
                var objeto = new ConceptoLiquidacion
                { 
                    Accion = "INSERTAR",
                    IdConcepto = conceptoLiquidacion.IdConcepto,
                    FechaLiquidacion = conceptoLiquidacion.FechaLiquidacion,
                    Comentarios = conceptoLiquidacion.Comentarios,
                    NumeroLiquidacion = conceptoLiquidacion.NumeroLiquidacion,
                    UsuarioCreacion = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarConceptoLiquidacion(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("IndexConceptoLiquidacion");
                }
                else
                {
                    return View("CreateConceptoLiquidacion");
                }
            }
            catch
            {
                return View();
            }
        }



        // GET: Conceptos/Edit/5
        public ActionResult Edit(int id)
        {
           
            var dt = _servicio.ConsultarConcepto(new Conceptos
            {
                Accion = "CONSULTAR_CONCEPTO",
                IdConcepto = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
                
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.Conceptos
            {
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                Concepto= dataRow.Field<string>("CONCEPTO"),
                TipoConcepto = dataRow.Field<string>("TIPOCONCEPTO"),
                Descripcion = dataRow.Field<string>("DESCRIPCION"),
                Unidad = dataRow.Field<string>("UNIDAD"),
                Salarial = dataRow.Field<bool>("SALARIAL"),
                Fijo = dataRow.Field<bool>("FIJO"),
                Liquidable = dataRow.Field<bool>("LIQUIDABLE"),
                Excluyente = dataRow.Field<bool>("EXCLUYENTE"),
                CantidadEditable = dataRow.Field<bool>("CANTIDADEDITABLE"),
                MontoEditable = dataRow.Field<bool>("MONTOEDITABLE"),
                UsaCantidad = dataRow.Field<bool>("USACANTIDAD"),
                UsaMonto = dataRow.Field<bool>("USAMONTO"),
                FormulaDefinida = dataRow.Field<bool>("FORMULADEFINIDA"),
                ImprimeComprobante = dataRow.Field<bool>("IMPRIMECOMPROBANTE"),
                ImprimeAcumulado = dataRow.Field<bool>("IMPRIMEACUMULADO"),
                FactorRedondeo = dataRow.Field<decimal>("FACTORREDONDEO"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")


            }).FirstOrDefault();

            return View(usr);

        }

        // POST: Conceptos/Edit/5
        [HttpPost]
        public ActionResult Edit(Conceptos conceptos)
        {

            try
            {
                var objeto = new Conceptos
                {
                    Accion = "ACTUALIZAR",
                    IdConcepto = conceptos.IdConcepto,
                    Concepto = conceptos.Concepto,
                    TipoConcepto = conceptos.TipoConcepto,
                    Descripcion = conceptos.Descripcion,
                    Unidad = conceptos.Unidad,
                    Salarial = conceptos.Salarial,
                    Fijo = conceptos.Fijo,
                    Liquidable = conceptos.Liquidable,
                    Excluyente=conceptos.Excluyente,
                    CantidadEditable = conceptos.CantidadEditable,
                    MontoEditable = conceptos.MontoEditable,
                    UsaCantidad = conceptos.UsaCantidad,
                    UsaMonto = conceptos.UsaMonto,
                    FormulaDefinida = conceptos.FormulaDefinida,
                    ImprimeComprobante= conceptos.ImprimeComprobante,
                    ImprimeAcumulado= conceptos.ImprimeAcumulado,
                    FactorRedondeo= conceptos.FactorRedondeo,
                    UsuarioCreacion = conceptos.UsuarioCreacion,
                    FechaCreacion = conceptos.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarConcepto(objeto);

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

        //Editar concepto formula
        public ActionResult EditConceptoFormula(int id)
        {
            ViewBag.concepto = GetConcepto();

            var dt = _servicio.ConsultarConceptoFormula(new ConceptoFormula
            {
                Accion = "CONSULTAR2",
                IdConceptoFormula = id,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now

            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.ConceptoFormula
            {

                IdConceptoFormula = dataRow.Field<int>("IDCONCEPTOFORMULA"),
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                Secuencia = dataRow.Field<int>("SECUENCIA"),
                ValorInicial = dataRow.Field<int>("VALORINICIAL"),
                ValorFinal = dataRow.Field<int>("VALORFINAL"),
                CantidadMonto = dataRow.Field<int>("CANTIDADMONTO"),
                NivelFormula = dataRow.Field<int>("NIVELFORMULA"),
                UsaCantidad=dataRow.Field<bool>("USACANTIDAD"),
                UsaMonto=dataRow.Field<bool>("USAMONTO")
                

            }).FirstOrDefault();

            return View(usr);

        }

        // POST: ConceptoLiquidacion/Edit/5
        [HttpPost]
        public ActionResult EditConceptoFormula(Models.ConceptoFormula conceptoF)
        {

            try
            {
                var objeto = new ConceptoFormula
                {
                    Accion = "ACTUALIZAR",

                    IdConceptoFormula = conceptoF.IdConceptoFormula,
                    IdConcepto = conceptoF.IdConcepto,
                    Secuencia = conceptoF.Secuencia,
                    ValorInicial = conceptoF.ValorInicial,
                    ValorFinal = conceptoF.ValorFinal,
                    CantidadMonto = conceptoF.CantidadMonto,
                    NivelFormula=conceptoF.NivelFormula,
                    UsaCantidad=conceptoF.UsaCantidad,
                    UsaMonto=conceptoF.UsaMonto,
                    UsuarioCreacion = conceptoF.UsuarioCreacion,
                    FechaCreacion = conceptoF.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarConceptoFormula(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("IndexConceptoFormula");
                }
                else
                {
                    return View("IndexConceptoFormula");
                }
            }
            catch
            {
                return View();
            }

        }


        //editar concepto liquidacion
        public ActionResult EditConceptoLiquidacion(int id)
        {

            var dt = _servicio.ConsultarConceptoLiquidacion(new ConceptoLiquidacion
            {
                Accion = "CONSULTAR2",
                IdConceptoLiquidacion = id,
                FechaLiquidacion = DateTime.Now,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now

            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.ConceptoLiquidacion
            {

                IdConceptoLiquidacion = dataRow.Field<int>("IDCONCEPTOLIQUIDACION"),
                IdConcepto = dataRow.Field<int>("IDCONCEPTO"),
                FechaLiquidacion = dataRow.Field<DateTime>("FECHALIQUIDACION"),
                Comentarios = dataRow.Field<string>("COMENTARIOS"),
                NumeroLiquidacion = dataRow.Field<int>("NUMEROLIQUIDACION"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")


            }).FirstOrDefault();

            return View(usr);

        }

        // POST: ConceptoLiquidacion/Edit/5
        [HttpPost]
        public ActionResult EditConceptoLiquidacion(Models.ConceptoLiquidacion conceptoLQ)
        {

            try
            {
                var objeto = new ConceptoLiquidacion
                {
                    Accion = "ACTUALIZAR",

                    IdConceptoLiquidacion= conceptoLQ.IdConceptoLiquidacion,
                    IdConcepto = conceptoLQ.IdConcepto,
                    FechaLiquidacion = conceptoLQ.FechaLiquidacion,
                    Comentarios= conceptoLQ.Comentarios,
                    NumeroLiquidacion = conceptoLQ.NumeroLiquidacion,
                    UsuarioCreacion = conceptoLQ.UsuarioCreacion,
                    FechaCreacion = conceptoLQ.FechaCreacion,
                    UsuarioModificacion = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };

                var dt = _servicio.ProcesarConceptoLiquidacion(objeto);

                if (dt.IsSuccess)
                {
                    return RedirectToAction("IndexConceptoLiquidacion");
                }
                else
                {
                    return View("IndexConceptoLiquidacion");
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: Conceptos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conceptos/Delete/5
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
