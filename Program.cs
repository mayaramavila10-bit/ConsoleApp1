using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        string[] codigo = { "OC-101", "OC-102", "OC-103", "OC-104", "OC-105", "OC-106" };
        string[] proveedores = { "TechCorp", "LogiExpress", "InsumosGlobal", "TechCorp", "AlfaSuministros", "ServiRedes" };

        double[,] datos =
        {
                {150.0, 10 },
                {450.0, 2 },
                {80.0, 50 },
                {1200, 1 },
                {25.0, 100 },
                {600, 3 },
         };

        static bool validar_datos(double precio, double cantidad)
        {
            if (precio > 0 || cantidad > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("horror la cantidad debe de ser mayor a 0");
                return false;
            }
        }

    public static void validarentrada()
        {
            Console.WriteLine("******************** MÓDULO VALIDAR ENTRADA ******************** ");
            bool todovalido = true;

            for (int i = 0; i < codigo.Length; i++)
            {
                Console.WriteLine($"Validación orden {codigo[i]} = ");
                if (validar_dattos(datos[i, 0])(datos[i, 1]))
                {
                    todovalido = false;
                }
                else
                {
                    Console.WriteLine("Tdo valido c:");
                }

                if (todovalido)
                {
                    Console.WriteLine("Todo correcto con la validación");
                }
            }
        }
    public static void reporteyacumuladores()
        {
            Console.WriteLine("******************** MÓDULO REPORTE Y ACOMULADORES********************");
            double totalfinal = 0;
                int contadordemayoria = 0;

            for (int i = 0; i< codigo.Length; i++)
            {
                double preciounitario = datos[i, 0];
                double cantidad = datos[i, 1];
                double montoneto = preciounitario * cantidad;

                totalfinal += montoneto;

                if (montoneto > 1000.0)
                {
                    contadordemayoria++;
                }

                Console.WriteLine($"Código: {codigo[i]} | preveedor: {proveedores[i]} || precio: ${preciounitario[i]} ||cantidad: {cantidad} || neto: ${montoneto:N2}  ");
            }

            Console.WriteLine("*********************************");
            Console.WriteLine($"TOTAL FINAL ACUMULADO: ${totalfinal:N2}");
            Console.WriteLine($"Contador de compras mayoristas(>$1,000): {contadordemayoria}");

        }

        public static void ordenamientoburbujadesendiente()
        {

            Console.WriteLine("******************** MÓDULO REPORTE Y ACOMULADORES********************");

            int n = codigo.Length;

            for (int i =0; i < codigo.Length; i++)
            {
                for (int  j = 0; j< n -1-i; j++)
                {
                    double montoJ = datos[j, 0] * datos[j, 1];
                    double montosiguiente = datos[j + 1, 2] * datos[j + 1, 1];

                    if (montoJ < montosiguiente)
                    {
                        double tempprecio = datos[j, 0];
                        double tempeCantidad = datos[j, 0];
                        datos[j, 0] = datos[j + 1, 0];
                        datos[j, 1] = datos[j + 1, 0];
                        datos[j + 1, 0] = tempprecio;
                        datos[j + 1, 0] = tempeCantidad;

                        string tempcod = codigos[j];
                        codigos[j] = codigos[i + 1];
                        codigos[j + 1] = tempcod;

                        StringDictionary temppro = proveedores[j];
                        proveedores[j] = proveedores[j + 1];
                        proveedores[j + 1] = temppro;
                    }

                    Console.WriteLine("Datos ordenamos c:");

                    for (int i = 0; i < datos.Length; i++)
                    {
                        double montoneto = datos[i, 0] * datos[i, 1];
                        Console.WriteLine($" {i + i}. Códigos: | preveedor: {proveedores[i]} || precio: ${preciounitario[i]} ||cantidad: {cantidad} || neto: ${montoneto:N2}  ");

                    }
                }
            }

        }
            

        static void Main(string[] args)
        {
            int opción;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" \t órdenes de compra");
                Console.WriteLine("[1] Validar datos de entrada");
                Console.WriteLine("[2] reportes y acumulador");
                Console.WriteLine(["[3] ORDENAMIENTOASCENDENTE BBURBUJA");
                Console.WriteLine("[4] SALIR DEL PROGRAMA");

                Console.WriteLine("Ingrese opción:");
                opción = Convert.ToInt32(Console.ReadLine());

                switch (opción)
                {
                    case 1:
                        validar_datos();
                        break;
                    case 2:
                        reporteyacumuladores();
                        break;
                    case 3:
                        ordenamientoburbujadesendiente();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo el programa");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("OPCION NO VALIDA");
                        break;

                }
                        Console.ReadKey();
            }

        }
    }
}
