using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoEF.Model;

namespace EmpleoEF
{
    public interface IEmpresa
    {
        void Alta(Empleado emple);
        Empleado BuscarId(int id);
        IEnumerable<Empleado> BuscarSalario(double salario);
        void DarBaja(Empleado emple);
        double SalarioMedioEmpleados();//si el salario lo hubiesemos puesto en la bbdd como nulable tendriamos que ponerlo double? SalarioMedioEmpleados();
        IEnumerable<Empleado> EmpleadosProyecto(int id);
        IEnumerable<Proyecto> ProyectoEmpleados(int id);
        IEnumerable<Empleado> EmpleadosPorNombre(String nombre);
        String[] EmpleadosNombre();
    }
}
