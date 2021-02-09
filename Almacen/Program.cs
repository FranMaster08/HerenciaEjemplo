using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    class Program
    {
        static List<Vehiculo> ListaVehiculos = new List<Vehiculo>();
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 5) + "Bienvenido" + new string('-', 5));
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Que tipo de Vehiculo desea Guardar\n a-) Motocicleta.\n b-) Buque.");

                string Decision = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                if (Decision.ToLower() == "a")
                {
                    Console.WriteLine("Usted escogio Motos");
                    IncluirMotocicleta();
                }


                if (Decision.ToLower() == "b")
                {
                    Console.WriteLine("Usted escogio Buques");
                    IncluirBuques();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("¿Desea Continuar agregando Vehiculos? Y/N");
                string continua = Console.ReadLine();
                if (continua.ToLower() == "n")
                    break;

            }

            Console.WriteLine(new string('-', 15) + "Imprimiendo motos" + new string('-', 15));
            int Cont = 1;
            foreach (var item in ListaVehiculos)
            {
                if (item.GetType().ToString() == "Almacen.Motocicleta")
                {
                    Console.WriteLine($"Info Moto Nr°{Cont}");
                    Motocicleta moto = (Motocicleta)item;
                    Console.WriteLine($"Peso Moto: {moto.Peso}");
                    Console.WriteLine($"Velocidad Moto:{moto.Velocidad}");
                    Console.WriteLine("--Info de las ruedas--");
                    Console.WriteLine("Presion moto: "+ moto.Rueda.PresionMaxima);
                    Console.WriteLine("Tamaño Moto: "+moto.Rueda.Tamanio);
                    Console.WriteLine("Talon Moto: "+moto.Rueda.Talon);
                    Cont++;
                }
            }
            Cont = 1;
            Console.WriteLine(new string('-', 15) + "Imprimiendo Buque Tanques" + new string('-', 15));
            foreach (var item in ListaVehiculos)
            {
                if (item.GetType().ToString() == "Almacen.BuqueTanque")
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine(new string('-', 15) + "Imprimiendo Buque Remolcador" + new string('-', 15));

            foreach (var item in ListaVehiculos)
            {
                if (item.GetType().ToString() == "Almacen.BuqueRemolcador")
                {
                    Console.WriteLine(item);
                }
            }


            Console.WriteLine($"Se instanciaron {ListaVehiculos.Count} Vehiculos");
            Console.WriteLine("Gracias por usar nuestros Programas");




            Console.ReadLine();


        }

        public static void IncluirMotocicleta()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Indique el peso de la motocicleta.");
            int pesoMoto = int.Parse(Console.ReadLine());
            Console.WriteLine("Indique la velocidad de la motocicleta.");
            int velocidadMoto = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique el tamaño de la motocicleta.");
            int TamanioRueda = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique la presion Maxima de la motocicleta.");
            int PresionMaximaRueda = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique el Talon de la motocicleta.");
            int TalonRueda = int.Parse(Console.ReadLine());

            Rueda rueda = new Rueda();
            rueda.Talon = TalonRueda;
            rueda.Tamanio = TamanioRueda;
            rueda.PresionMaxima = PresionMaximaRueda;

            Motocicleta motocicletaX = new Motocicleta();
            motocicletaX.Peso = pesoMoto;
            motocicletaX.Velocidad = velocidadMoto;
            motocicletaX.Rueda = rueda;

            ListaVehiculos.Add(motocicletaX);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Motocicleta Agregada");
        }

        public static void IncluirBuques()
        {
            Console.WriteLine("Indique la velocidad del Buque.");
            int VelocidadBuque = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique la Longitud del Buque.");
            int LongitudBuque = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique el Ancho del  Buque.");
            int AnchBuque = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique tipo Buque:\n 1-) Tanque.\n 2-) Remolcador.");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() == "1")
            {
                Console.WriteLine("Indique capacidad de tanque.");
                int capacidadTanque = int.Parse(Console.ReadLine());
                BuqueTanque buqueTanque = new BuqueTanque();
                buqueTanque.Ancho = AnchBuque;
                buqueTanque.CapacidadTanque = capacidadTanque;
                buqueTanque.Velocidad = VelocidadBuque;
                buqueTanque.Longitud = LongitudBuque;
                ListaVehiculos.Add(buqueTanque);

            }
            else
            {
                Console.WriteLine("Indique capacidad de remolque.");
                int capacidadremolque = int.Parse(Console.ReadLine());
                BuqueRemolcador BuqueRemolcador = new BuqueRemolcador();
                BuqueRemolcador.Ancho = AnchBuque;
                BuqueRemolcador.CapacidadRemolque = capacidadremolque;
                BuqueRemolcador.Velocidad = VelocidadBuque;
                BuqueRemolcador.Longitud = LongitudBuque;
                ListaVehiculos.Add(BuqueRemolcador);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usted Agrego un Buque a Lista");
        }
    }
}
