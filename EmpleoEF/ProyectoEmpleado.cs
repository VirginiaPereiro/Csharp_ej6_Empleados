using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoEF.Model;

namespace EmpleoEF
{
    class ProyectoEmpleado
    {
        private EmpleoEntities db = new EmpleoEntities();

        public String Proyecto{ get; set; }
        public String Empleado{ get; set; }

    }
}
