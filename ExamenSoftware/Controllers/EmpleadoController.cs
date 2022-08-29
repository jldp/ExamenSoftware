using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenSoftware.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarEmpleado() {

            PruebaDataContext bd = new PruebaDataContext();

            var lista = (from emp in bd.empleados
                         join area in bd.areas
                         on emp.id_area equals area.id_area
                         //where area.id_area.Equals(id)
                         select new
                         {
                             //area.id_area,
                             EmpId = emp.id_empleado,
                             EmpNombre = emp.nombre,
                             EmpApaterno = emp.apellidoPaterno,
                             EmpCorreo = emp.correo,
                             AreaName = area.nombre

                         }).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarArea()
        {

            PruebaDataContext bd = new PruebaDataContext();
            var lista = (bd.areas.Where(p => p.id_area>0)
                .Select(p => new { IID = p.id_area, p.nombre })).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);


        }
        /*public JsonResult pruebaArea()
        {

            PruebaDataContext bd = new PruebaDataContext();

            var lista = (from emp in bd.empleados
                         join area in bd.areas
                         on emp.id_area equals area.id_area
                         //where area.id_area.Equals(id)
                         select new
                         {
                             //area.id_area,
                             EmpId=emp.id_empleado,
                             EmpNombre=emp.nombre,
                             EmpApaterno=emp.apellidoPaterno,
                             EmpCorreo=emp.correo,
                             AreaName=area.nombre                             

                         }).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }**/
    }
}