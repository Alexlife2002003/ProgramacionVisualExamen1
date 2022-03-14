using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace roullete
{
    class Ruleta
    {
        Black black;
        Red red;
        Jugador jugador;

        public Ruleta()
        {
            black= new Black();
            red=new Red();
            jugador=new Jugador();
        }

        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Control de Ruleta");
                Console.WriteLine("1.- Apostar");
                Console.WriteLine("2.- Historial de Giros");
                Console.WriteLine("3.- Estadisticas");
                Console.WriteLine("4.- Retirarse");

            } while (!validaMenu(5, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {
                case 1:
                    showMenuApostar();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Console.WriteLine("Retirarse");
                    break;
             

            }
        }
        public void showMenuApostar()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Control de Apostar");
                Console.WriteLine("1.- Apostar a un numero especifico");
                Console.WriteLine("2.- Apostar por un color");
                Console.WriteLine("3.- Apostar si es par o impar");
                Console.WriteLine("4.- Salir");

            } while (!validaMenu(4, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {
                case 1:
                    apostarNumeroEspecifico();
                    showMenuPrincipal();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;


            }
        }

        public void apostarNumeroEspecifico()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el numero por el cual quiere apostar");
            Boolean value = false;
            while (value == false) {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    value = true;
                    Console.WriteLine("Ha metido entero valido");
                    Console.ReadLine();

                }
            }
            

        }

        public int girarRuleta()
        {
            return 0;
        }
        private bool validaMenu(int opciones, ref int opcionSeleccionada)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones)
                {
                    opcionSeleccionada = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opcion Invalida");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es valido, debes ingresar un numero");
                return false;
            }
        }


    }
}
