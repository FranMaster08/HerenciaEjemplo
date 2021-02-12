using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aberturas
{
    class Program
    {
      
        static List<Abertura> ListadoAberturas = new List<Abertura>();
        static List<Abertura> ListadoAberturasExistentes = new List<Abertura>();
        static void Main(string[] args)
        {

            //mostramos el Menu
            int resultado = MostrarMenu();
            //le pasamos el menu escogido a realizar acciones
            RealizarAcciones(resultado);

            string desicion = Console.ReadLine();
            Console.WriteLine("Para Salir oprima (N) , cualquier otra tecla para continuar");

            if (desicion.ToLower().Equals("n"))
            {
                Console.WriteLine("Gracias..");
            }
            else
            {
                Main(null);
            }
            Console.ReadLine();
        }


        public static int MostrarMenu()
        {
            int menuSeleccionado = 0;
            try
            {
                string textoMenu = @"
                                -------Menu--------
                                1.	Agregar una puerta .
                                2.	Agregar una ventana .
                                3.	Eliminar una ventana .
                                4.	Eliminar una puerta .
                                5.	Visualizar información de todas las aberturas creadas .
                                6.	Visualizar la cantidad de aberturas existentes .
                                7.	Visualizar la superficie de madera utilizada de todas las aberturas.
                                 ";
                Console.WriteLine(textoMenu);
                menuSeleccionado = int.Parse(Console.ReadLine());
                if (menuSeleccionado < 1 || menuSeleccionado > 7)
                {
                    Console.WriteLine("Por favor ingrese una opcion valida.");
                    MostrarMenu();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Por favor ingrese un dato numerico.");
                MostrarMenu();
            }
            return menuSeleccionado;
        }

        public static void RealizarAcciones(int menu)
        {
            switch (menu)
            {
                case 1:
                    AgregarAbertura("Puerta");
                    break;
                case 2:
                    AgregarAbertura("Ventana");
                    break;
                case 3:
                    EliminarAbertura("Ventana");
                    break;
                case 4:
                    EliminarAbertura("Puerta");
                    break;
                case 5:
                    MostrarAberturas("todas");
                    break;
                case 6:
                    MostrarAberturas("existentes");
                    break;
                case 7:
                    MostrarAberturas("superficies");
                    break;
                default:

                    break;
            
            }
        }

        private static void MostrarAberturas(string v)
        {
            switch (v)
            {
                case "todas":
                    for (int i = 0; i < ListadoAberturas.Count; i++)
                    {
                        Console.WriteLine($"Informacion de la Abertura en la posicion [{i}]");
                        Console.WriteLine(new string('=', 30));
                        if (ListadoAberturas[i].GetType().ToString().Contains("Puerta"))
                        {
                            Console.WriteLine("Tipo Abertura: Puerta");
                            Puerta puerta = (Puerta)ListadoAberturas[i];
                            Console.WriteLine($"Cantidad de Bisagras:{puerta.cantidadBisagras}");
                        }
                        if (ListadoAberturas[i].GetType().ToString().Contains("Ventana"))
                        {
                            Console.WriteLine("Tipo Abertura: Ventana");
                            Ventana ventana = (Ventana)ListadoAberturas[i];
                            Console.WriteLine($"Es de Doble vidrio :{ventana.TieneDobleVidrio()}");
                        }

                        Console.WriteLine($"Alto: {ListadoAberturas[i].Alto}");
                        Console.WriteLine($"Ancho: {ListadoAberturas[i].Ancho}");
                        Console.WriteLine($"SuperFicie: {ListadoAberturas[i].Alto + ListadoAberturas[i].Ancho}");
                        Console.WriteLine(new string('=', 30));
                    }
                    break;
                case "existentes":
                    for (int i = 0; i < ListadoAberturasExistentes.Count; i++)
                    {
                        Console.WriteLine($"Informacion de la Abertura  en la posicion [{i}]");
                        Console.WriteLine(new string('=',30));
                        if (ListadoAberturasExistentes[i].GetType().ToString().Contains("Puerta"))
                        {
                            Console.WriteLine("Tipo Abertura: Puerta");
                            Puerta puerta = (Puerta)ListadoAberturasExistentes[i];
                            Console.WriteLine($"Cantidad de Bisagras:{puerta.cantidadBisagras}");
                        }
                        if (ListadoAberturasExistentes[i].GetType().ToString().Contains("Ventana"))
                        {
                            Console.WriteLine("Tipo Abertura: Ventana");
                            Ventana ventana = (Ventana)ListadoAberturasExistentes[i];
                            Console.WriteLine($"Es de Doble vidrio :{ventana.TieneDobleVidrio()}");
                        }

                        Console.WriteLine($"Alto: {ListadoAberturasExistentes[i].Alto}");
                        Console.WriteLine($"Ancho: {ListadoAberturasExistentes[i].Ancho}");
                        Console.WriteLine($"SuperFicie: {ListadoAberturasExistentes[i].Alto + ListadoAberturasExistentes[i].Ancho}");
                        Console.WriteLine(new string('=', 30));
                    }
                    break;
                case "superficies":
                    int sumatoriaSuper = 0;
                    foreach (var item in ListadoAberturas)
                    {
                        sumatoriaSuper += (item.Alto + item.Ancho);
                    }
                    Console.WriteLine(new string('=', 30));
                    Console.WriteLine($"La superficie total de las maderas utilizada fue: {sumatoriaSuper}");
                    Console.WriteLine(new string('=', 30));
                    break;
                default:
                    break;
            }
        }

        private static void EliminarAbertura(string v)
        {
            try
            {
                Console.WriteLine("Ingrese el indice que desea  eliminar de la lista");
                int indexBuscado = int.Parse(Console.ReadLine());
                if (indexBuscado<0 || indexBuscado>ListadoAberturas.Count-1)
                {
                    Console.WriteLine("Indice inexistente");
                    return;
                }

                bool respuesta = ListadoAberturas[indexBuscado].GetType().ToString().Contains(v);
                if (respuesta == true)
                {
                    ListadoAberturasExistentes.RemoveAt(indexBuscado);
                    Console.WriteLine($"Se marco la abertura con el indice {indexBuscado} como eliminada");
                }
                else
                {
                    Console.WriteLine($"No se puede eliminar por este metodo por que el indice {indexBuscado} no es una {v}");
                }
               

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ingreso un valor no numerico para el indice");
               
            }
       
        }

        private static void AgregarAbertura(string v)
        {
            try
            {
                Console.WriteLine($"Ingresar {v}");
                Console.WriteLine();
                Console.WriteLine("Ingrese el ancho");
                int Ancho = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el alto.");
                int Alto = int.Parse(Console.ReadLine());

                if (v.Equals("Puerta"))
                {
                    Console.WriteLine("Ingrese la cantidad de Bisagras");
                    int bisagras = int.Parse(Console.ReadLine());
                    Puerta puerta = new Puerta();
                    puerta.Ancho = Ancho;
                    puerta.Alto = Alto;
                    puerta.cantidadBisagras = bisagras;
                    ListadoAberturas.Add(puerta);
                    ListadoAberturasExistentes.Add(puerta);
                    Console.WriteLine("Se ingreso Puerta");
                }
                if (v.Equals("Ventana"))
                {
                    bool dobleVidrio = false;
                    while (true)
                    {
                        Console.WriteLine("Indique si es Doble Vidrio y/n");
                        string desicion = Console.ReadLine();
                        if (desicion.ToLower().Equals("y"))
                        {
                            Console.WriteLine("Se ingreso Ventana");
                            dobleVidrio = true;
                            break;
                        }
                        if (desicion.ToLower().Equals("n"))
                        {
                            Console.WriteLine("Se ingreso Ventana");
                            dobleVidrio = false;
                            break;
                        }
                        Console.WriteLine("Ingrese un valor valido");

                    }

                    Ventana ventana = new Ventana();
                    ventana.Ancho = Ancho;
                    ventana.Alto = Alto;
                    ventana.doblevidrio = dobleVidrio;
                    ListadoAberturas.Add(ventana);
                    ListadoAberturasExistentes.Add(ventana);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ingrese valores en el formato adecuado");
            

            }




        }
    }
}
