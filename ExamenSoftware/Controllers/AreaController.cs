
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenSoftware.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarArea()
        {

            PruebaDataContext bd = new PruebaDataContext();
            var lista = bd.areas.Where(p => p.id_area > 0)
                .Select(p => new { p.id_area, p.nombre }).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult recuperarDatos(int id)
        {

            PruebaDataContext bd = new PruebaDataContext();

            var lista = (from area in bd.areas
                         where area.id_area.Equals(id)
                         select new
                         {
                             area.id_area,
                             area.nombre,

                         }).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public int guardarDatos(areas oarea) {//areas oarea nombre de la clase mapeada por linq, nombre de la tabla en BD

            PruebaDataContext bd = new PruebaDataContext();
            int nregistrosAfectados = 0;
            try
            {
                if (oarea.id_area == 0)//se compara id_area si es igual es 0, es porque es una registro nuevo
                {
                    bd.areas.InsertOnSubmit(oarea);
                    bd.SubmitChanges();
                    nregistrosAfectados = 1;
                }
                else { //sino, es porque es un actualizar

                    areas areasSel = (from a in bd.areas where a.id_area.Equals(oarea.id_area) select a).FirstOrDefault();
                    areasSel.nombre = oarea.nombre;
                    bd.SubmitChanges();
                    nregistrosAfectados = 1;


                }

            }
            catch (Exception ex) {

                nregistrosAfectados = 0;


            }

            return nregistrosAfectados;

        }

        public int eliminarArea(areas oarea) {//se recibe objeto de tipo areas

            PruebaDataContext bd = new PruebaDataContext();
            int nregistrosAfectados = 0;
            try
            {
                /*areas areasSel = (from a in bd.areas where a.id_area.Equals(oarea.id_area) select a).FirstOrDefault();
                areasSel.remo
                bd.SubmitChanges();
                nregistrosAfectados = 1;
                */
                var detallesArea = from a in bd.areas where a.id_area.Equals(oarea.id_area) select a;
                foreach (var detalle in detallesArea) {

                    bd.areas.DeleteOnSubmit(detalle);

                }
                bd.SubmitChanges();
                nregistrosAfectados = 1;

            }
            catch (Exception ex) {

                nregistrosAfectados = 0;

            }

            return nregistrosAfectados;
        }
    }
}