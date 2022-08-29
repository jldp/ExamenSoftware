using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSoftware.Models
{
    public class Empleado
    {

        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string correo { get; set; }
        public int id_area { get; set; }
    }
}