using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoEF.Model;

namespace EmpleoEF
{
    public class RepositorioEmpleados
    {
        private EmpleoEntities db = new EmpleoEntities();

        public void Alta(Empleado emple)
        {
            db.Empleado.Add(emple);
            db.SaveChanges();
        }

        public Empleado GetById(int id)
        {
            // Find busca por clave primaria, sólo podrá haber un resultado
            return db.Empleado.Find(id);
        }

        public IEnumerable<Empleado> GetBySalario(double salario)
        {
            //que el objeto recibido sea mayor o igual al salario introducido
            return db.Empleado.Where(o => o.salario >= salario);
        }

        public void DarBaja(Empleado emple)
        {
            db.Empleado.Remove(emple);
            db.SaveChanges();
        }

        public double SalarioMedioEmpleados()
        {
            return db.Empleado.Average(o => o.salario);
        }


        public IEnumerable<Empleado> EmpleadosProyecto(int id)
        {
            var datos = db.Proyecto.First(o => o.id == id).Empleado;
            return datos;
        }


        public IEnumerable<Proyecto> ProyectoEmpleados(int id)
        {
            var datos =db.Empleado.First(o => o.id == id).Proyecto;
            return datos;
        }

        public String[] EmpleadosNombre()
        {
            var nombres = db.Empleado.Select(o => o.nombre);
            return nombres.ToArray();
        }
    }
}
