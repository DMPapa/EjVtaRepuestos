using EjVtaRepuestos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjVtaRepuestos
{
    class Program
    {
        static void Main(string[] args)
        {
            VentaRepuestos e1 = new VentaRepuestos("Repuestos DeTodo", "Calle Falsa 123");
            Categoria c1 = new Categoria(1, "general");
            Categoria c2 = new Categoria(2, "especifico");
            Categoria c3 = new Categoria(3, "raro");

            Console.WriteLine("Bienvenido a: " + e1.NombreComercio);

            bool finalizar = false;
            do
            {
                int eleccion = ConsolaHelper.PedirNumero(
                    "\nSelecione opción: \n" +
                    "1- Agregar Repuesto \n" +
                    "2- Quitar Repuesto \n" +
                    "3- Modificar Precio \n" +
                    "4- Agregar Stock \n" +
                    "5- Quitar Stock \n" +
                    "6- Traer por Categoria \n" +
                    "7- Salir \n");


                if (eleccion > 7 || eleccion < 0)
                    throw new Exception("\n--Debe ingresar una opción válida--\n");

                else
                    switch (eleccion)
                    {
                        case 1:
                            
                            e1.AgregarRepuesto(
                                ConsolaHelper.PedirNumero("Ingrese código del repuesto"),
                                ConsolaHelper.PedirTexto("Ingrese nombre del repuesto"),
                                ConsolaHelper.PedirDouble("Ingrese precio del repuesto"),
                                ConsolaHelper.PedirNumero("Ingrese stock inicial"),
                                ConsolaHelper.PedirNumero("Ingrese código de la categoria)")); ;
                            break;
                        case 2:
                            e1.QuitarRepuesto(ConsolaHelper.PedirNumero("Ingrese código del repuesto a quitar"));
                            break;
                        case 3:
                            e1.ModificarPrecio(
                                ConsolaHelper.PedirNumero("Ingrese código del repuesto a modificar precio"),
                                ConsolaHelper.PedirDouble("Ingrese nuevo precio"));
                            break;
                        case 4:
                            e1.AgregarStock(
                                ConsolaHelper.PedirNumero("Ingrese código del repuesto a modificar stock"),
                                ConsolaHelper.PedirNumero("Ingrese stock a agregar"));
                            break;
                        case 5:
                            e1.QuitarStock(
                                ConsolaHelper.PedirNumero("Ingrese código del repuesto a modificar stock"),
                                ConsolaHelper.PedirNumero("Ingrese stock a quitar"));
                            break;
                        case 6:
                            string listado = null;
                            foreach (Repuesto rep in e1.TraerPorCategoria(ConsolaHelper.PedirNumero("Ingrese código de la categoría")))
                            { listado += rep.ToString() + "\n"; }
                            ConsolaHelper.Mensaje(listado);
                            break;
                        case 7:
                            finalizar = true;
                            break;
                    }
            } while (finalizar == false);

        }
    }
}
