using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoEF.Model;

namespace EmpleoEF
{
    class Program
    {
        static EmpleoEntities db = new EmpleoEntities();

        static RepositorioEmpleados ie = new RepositorioEmpleados();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1.Dar de alta\n2.Buscar por id\n3.Buscar por salario" +
                                  "\n4.Dar de baja\n5.Salario medio de empleados\n6.Empleados por proyecto" +
                                  "\n7.Proyectos por empleado\n8.Empleados por nombre\n9.Salir");
                Int32.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        Alta();
                        break;
                    case 2:
                        BuscarId();
                        break;
                    case 3:
                        BuscarSalario();
                        break;
                    case 4:
                        DarBaja();
                        break;
                    case 5:
                        SalarioMedioEmpleados();
                        break;
                    case 6:
                        EmpleadosProyecto();
                        break;
                    case 7:
                        ProyectoEmpleados();
                        break;
                    case 8:
                        EmpleadosNombre();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta");
                        break;
                }

            } while (opcion != 9);

        }

        private static void Alta()
        {
            //DAR DE ALTA
            Console.WriteLine("Introduzca nombre");
            var newNombre = Console.ReadLine();

            Console.WriteLine("Introduzca dni");
            var newDni = Console.ReadLine();

            int newCargo;
            Console.WriteLine("Introduzca cargo, 1.Programador 2.Diseñador 3.Administrador");
            int.TryParse(Console.ReadLine(), out newCargo);

            int newsalario;
            Console.WriteLine("Introduzca salario");
            int.TryParse(Console.ReadLine(), out newsalario);

         
            var empleado = new Empleado()
            {
                nombre = newNombre,
                dni = newDni,
                idCargo = newCargo,
                salario = newsalario
            };

            ie.Alta(empleado);

        }

        private static void BuscarId()
        {
            //BUSCAR POR ID
            var empleados = new RepositorioEmpleados();

            int buscaId;
            Console.WriteLine("Introduzca id para buscar");
            int.TryParse(Console.ReadLine(), out buscaId);

            var empleado = empleados.GetById(buscaId);

            if (empleado == null)
            {
                Console.WriteLine("No existe empleado");
            }
            else
            {
                Console.WriteLine("El empleado con el id {0}, su nombre es {1}, su dni es {2}," +
                              "el id del cargo es {3} y su saliro es de {4}",
                empleado.id, empleado.nombre, empleado.dni, empleado.idCargo, empleado.salario);
            }
        }

        private static void BuscarSalario()
        {
            //BUSCAR POR SALARIO
            var ae = new RepositorioEmpleados();

            int buscaSalario;
            Console.WriteLine("Introduzca salario para buscar");
            int.TryParse(Console.ReadLine(), out buscaSalario);

            var empleados = ae.GetBySalario(buscaSalario);
            var contador = 0;
           
            foreach (var empleado in empleados)
            {
                if (empleado == null)
                {
                    Console.WriteLine("No existe empleado");
                }
                else
                {
                    contador++;
                    Console.WriteLine("{0}. El empleado con el id {1}, su nombre es {2}, su dni es {3}, " +
                            "el id del cargo es {4} y su saliro es de {5}",
                            contador, empleado.id, empleado.nombre, empleado.dni, empleado.idCargo, empleado.salario);
                }
              
            }

        }

        private static void DarBaja()
        {
            int introduceId;
            Console.WriteLine("Introduzca id para dar de baja");
            int.TryParse(Console.ReadLine(), out introduceId);

            var empleado = db.Empleado.Find(introduceId);

            if (empleado == null)
            {
                Console.WriteLine("No existe empleado");
            }
            else
            {
                db.Empleado.Remove(empleado);
                db.SaveChanges();
            }

        }

        private static double SalarioMedioEmpleados()
        {
            var mediaSaldo = ie.SalarioMedioEmpleados();
            Console.WriteLine(mediaSaldo);
            return mediaSaldo;
        }

        private static void EmpleadosProyecto()
        {
            int buscaEmpleados;
            Console.WriteLine("Introduzca identificador de proyecto");
            int.TryParse(Console.ReadLine(), out buscaEmpleados);

            var empleados = ie.EmpleadosProyecto(buscaEmpleados);

            foreach (var empleado in empleados)
            {
                Console.WriteLine(empleado.nombre);
            }
        }


        private static void ProyectoEmpleados()
        {
            int buscaProyectos;
            Console.WriteLine("Introduzca identificador de empleado");
            int.TryParse(Console.ReadLine(), out buscaProyectos);

            var proyectos =ie.ProyectoEmpleados(buscaProyectos);

            foreach (var proyecto in proyectos)
            {
                Console.WriteLine(proyecto.Nombre);
            }
        }


        private static void EmpleadosNombre()
        {
            var empleados =ie.EmpleadosNombre();

            foreach (var empleado in empleados)
            {
                Console.WriteLine(empleado);  
            }
            
        }

    }
}
