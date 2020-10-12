using EjVtaRepuestos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                        ConsolaHelper.Mensaje("\n--Debe ingresar una opción válida--\n");

                    else
                        switch (eleccion)
                        {
                            case 1:

                                e1.AgregarRepuesto(
                                    ConsolaHelper.PedirNumero("\nIngrese código del repuesto\n"),
                                    ConsolaHelper.PedirTexto("\nIngrese nombre del repuesto\n"),
                                    ConsolaHelper.PedirDouble("\nIngrese precio del repuesto\n"),
                                    ConsolaHelper.PedirNumero("\nIngrese stock inicial\n"),
                                    ConsolaHelper.PedirNumero("\nIngrese código de la categoria\n")); ;
                                break;
                            case 2:
                                try
                                {
                                    e1.QuitarRepuesto(ConsolaHelper.PedirNumero("\nIngrese código del repuesto a quitar\n"));
                                }
                                catch (Exception ex1) { ConsolaHelper.Mensaje(ex1.Message); }
                                break;
                            case 3:
                                try
                                {
                                    e1.ModificarPrecio(
                                        ConsolaHelper.PedirNumero("\nIngrese código del repuesto a modificar precio\n"),
                                        ConsolaHelper.PedirDouble("\nIngrese nuevo precio\n"));
                                }
                                catch (Exception ex1) { ConsolaHelper.Mensaje(ex1.Message); }
                                break;
                            case 4:
                                try
                                {
                                    e1.AgregarStock(
                                        ConsolaHelper.PedirNumero("\nIngrese código del repuesto a modificar stock\n"),
                                        ConsolaHelper.PedirNumero("\nIngrese stock a agregar\n"));
                                }
                                catch (Exception ex1) { ConsolaHelper.Mensaje(ex1.Message); }
                                break;
                            case 5:
                                try
                                {
                                    e1.QuitarStock(
                                        ConsolaHelper.PedirNumero("\nIngrese código del repuesto a modificar stock\n"),
                                        ConsolaHelper.PedirNumero("\nIngrese stock a quitar\n"));

                                }
                                catch (StockNegativoException ex2) { ConsolaHelper.Mensaje(ex2.Message); }
                                catch (Exception ex1) { ConsolaHelper.Mensaje(ex1.Message); }
                                break;
                            case 6:
                                string listado = null;
                                foreach (Repuesto rep in e1.TraerPorCategoria(ConsolaHelper.PedirNumero("\nIngrese código de la categoría\n")))
                                { listado += rep.ToString() + "\n"; }
                                ConsolaHelper.Mensaje("\n" + listado);
                                break;
                            case 7:
                                finalizar = true;
                                break;
                        }
                } while (finalizar == false) ;
        }
    }
}
