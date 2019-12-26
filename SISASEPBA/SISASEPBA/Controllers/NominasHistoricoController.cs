using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SISASEPBA.ServicioAsepba;

namespace SISASEPBA.Controllers
{
    public class NominasHistoricoController : Controller
    {
        private readonly ServicioAsepba.ServiceAsepbaClient _servicio = new ServiceAsepbaClient();
        // GET: NominasHistorico
        [Authorize]
        public ActionResult Index()
        {
            var dt = _servicio.ConsultarNominasHistorico(new NominasHistorico
            {
                Accion = "CONSULTAR",
                FechaCreacion = DateTime.Now,
                FechaAprobacion = DateTime.Now,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now,
                Periodo = DateTime.Now,
                FechaPago = DateTime.Now,
                FechaAplicacion = DateTime.Now,
                FechaCalculo = DateTime.Now,
                FechaModificacion = DateTime.Now
            });

            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.NominasHistorico
            {
                IdNomina = dataRow.Field<int>("IDNOMINA"),
                Consecutivo = dataRow.Field<int>("CONSECUTIVO"),
                FechaInicio = dataRow.Field<DateTime>("FECHAINICIO"),
                FechaFin = dataRow.Field<DateTime>("FECHAFIN"),
                Periodo = dataRow.Field<DateTime>("PERIODO"),
                FechaPago = dataRow.Field<DateTime>("FECHAPAGO"),
                FechaCalculo = dataRow.Field<DateTime>("FECHACALCULO")

            }).ToList();

            return View(usr);
        }

        // GET: NominasHistorico/Details/5
        public ActionResult Details(int id, int dato )
        {
            var dt = _servicio.ConsultarNominasHistorico(new NominasHistorico
            {
                Accion = "CONSULTAR_DETALLE",
                IdNomina = id,
                Consecutivo = dato,
                FechaCreacion = DateTime.Now,
                FechaAprobacion = DateTime.Now,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now,
                Periodo = DateTime.Now,
                FechaPago = DateTime.Now,
                FechaAplicacion = DateTime.Now,
                FechaCalculo = DateTime.Now,
                FechaModificacion = DateTime.Now
            });
            var usr = dt.Tables[0].AsEnumerable().Select(dataRow => new Models.NominasHistorico
            {
                IdNomina = dataRow.Field<int>("IDNOMINA"),
                Consecutivo = dataRow.Field<int>("CONSECUTIVO"),
                FechaInicio = dataRow.Field<DateTime>("FECHAINICIO"),
                FechaFin = dataRow.Field<DateTime>("FECHAFIN"),
                Periodo = dataRow.Field<DateTime>("PERIODO"),
                FechaPago = dataRow.Field<DateTime>("FECHAPAGO"),
                FechaCalculo = dataRow.Field<DateTime>("FECHACALCULO"),
                UsuarioAprobacion = dataRow.Field<string>("USUARIOAPROBACION"),
                FechaAprobacion = dataRow.Field<DateTime>("FECHAAPROBACION"),
                UsuarioAplicacion = dataRow.Field<string>("USUARIOAPLICACION"),
                FechaAplicacion = dataRow.Field<DateTime>("FECHAAPLICACION"),
                UsuarioCreacion = dataRow.Field<string>("USUARIOCREACION"),
                FechaCreacion = dataRow.Field<DateTime>("FECHACREACION")
            }).FirstOrDefault();

            return View(usr);
        }

        
    }
}
