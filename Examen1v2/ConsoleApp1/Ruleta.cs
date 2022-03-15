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
        List<Tiros> _tiros;
        int tiroActual;
        int par;
        int impar;
        int rojos;
        int negros;
        List<Numero> numeros;
        List<Numero> _numeros;
        private IEnumerable<Numero> _orderedByTiro;

        public Ruleta()
        {
            black= new Black();
            red=new Red();
            jugador=new Jugador();
            _tiros=new List<Tiros>();
            numeros=new List<Numero>();
            _numeros=new List<Numero>();
            _orderedByTiro = new List<Numero>();
            tiroActual =0;
            par=0;
            impar=0;
            rojos = 0;
            negros = 0;
        }

        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Control de Ruleta");
                Console.WriteLine("1.- Apostar");
                Console.WriteLine("2.- Historial de Tiros");
                Console.WriteLine("3.- Estadisticas");
                Console.WriteLine("4.- Retirarse");

            } while (!validaMenu(5, ref opcionSeleccionada));
            int balance = jugador.Dinero;
            if (balance > 0)
            {
                switch (opcionSeleccionada)
                {
                    case 1:
                        showMenuApostar();
                        break;
                    case 2:
                        historialTiros();
                        showMenuPrincipal();
                        break;
                    case 3:
                        showMenuEstadisticas();
                        break;
                    case 4:
                        int dinero=jugador.Dinero;
                        if (dinero > 300) {
                            dinero = dinero - 300;
                            Console.WriteLine("Usted ha ganado " + dinero);
                        }
                        else
                        {
                            dinero = 300 - dinero;
                            Console.WriteLine("Usted ha perdido " + dinero);
                        }
                        Console.ReadLine();
                        Console.WriteLine("Retirarse");
                        break;


                }

            }
            else
            {
                Console.WriteLine("Se ha quedado sin dinero");
            }
            
        }

        public void historialTiros()
        {
            foreach(Tiros item in _tiros)
            {
                Console.Write(item.ToString()+"\n");
            }
            Console.ReadLine();
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
                Console.WriteLine("4.- Regresar");

            } while (!validaMenu(5, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {
                case 1:
                    apostarNumeroEspecifico();
                    showMenuPrincipal();
                    break;
                case 2:
                    apostarcolor();
                    showMenuPrincipal();
                    break;
                case 3:
                    ApostarParImpar();
                    showMenuPrincipal();
                    break;
                case 4:
                    showMenuPrincipal();
                    break;


            }
        }

        public void ApostarParImpar()
        {
            int ruleta = girarRuleta();
            string eleccion = EscogerParImpar();
            int apostar=cantidadApostar();
            int balance = jugador.Dinero;
            balance = balance - apostar;
            jugador.Dinero = balance;
            string ganador = "";
            tiroActual++;
            if(ruleta%2 == 0)
            {
                par++;
                ganador = "par";
            }
            else
            {
                impar++;
                ganador = "impar";
            }
            if (red.List.Contains(ruleta.ToString()))
            {
                rojos++;
            }
            if (black.List.Contains(ruleta.ToString()))
            {
                negros++;
            }
            Console.WriteLine("Ganador: " + ganador + " Eleccion: " + eleccion);
            if (ganador==eleccion)
            {
                balance = balance + (apostar * 2);
                jugador.Dinero = balance;
                Tiros tiro = new Tiros(tiroActual, ruleta, apostar, "ganado", "Apuesta por parImpar");
                _tiros.Add(tiro);
                Console.WriteLine("Ha ganado la apuesta");
                Console.ReadLine();
            }
            else
            {
                Tiros tiro = new Tiros(tiroActual, ruleta, apostar, "perdido", "Apuesta por parImpar");
                _tiros.Add(tiro);
                Console.WriteLine("Ha perdido la apuesta");
                Console.ReadLine();
            }
            
           

        }

        public void showMenuEstadisticas()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Control de Estadisticas");
                Console.WriteLine("1.- Balance");
                Console.WriteLine("2.- Cantidad de tiros realizdos");
                Console.WriteLine("3.- Numero que mas veces se ha tirado");
                Console.WriteLine("4.- Numero que menos veces se ha tirado");
                Console.WriteLine("5.- Cantidad de resultados rojos");
                Console.WriteLine("6.- Cantidad de resultados negros");
                Console.WriteLine("7.- Cantidad de resultados pares");
                Console.WriteLine("8.- Cantidad de resultados impares");
                Console.WriteLine("9.- Regresar");
            } while (!validaMenu(10, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {
                case 1:
                    int balance = jugador.Dinero;
                    Console.WriteLine("Su balance actual es de " + balance);
                    Console.ReadLine();
                    showMenuEstadisticas();
                    break;
                case 2:
                    Console.WriteLine("La cantidad de tiros realizados son:"+tiroActual);
                    Console.ReadLine();
                    showMenuEstadisticas();
                    break;
                case 3:
                    numeroMasTirado();
                    showMenuEstadisticas();
                    break;
                case 4:
                    numeroMenosTirado();
                    showMenuEstadisticas();
                    break;
                case 5:
                    Console.WriteLine("La cantidad de resultados rojos son:" + rojos);
                    Console.ReadLine();
                    showMenuEstadisticas();
                    break;
                case 6:
                    Console.WriteLine("La cantidad de resultados negros son :" + negros);
                    Console.ReadLine();
                    showMenuEstadisticas();
                    break;
                case 7:
                    Console.WriteLine("La cantidad de resultados pares son :" + par);
                    Console.ReadLine();
                    showMenuEstadisticas();
                    break;
                case 8:
                    Console.WriteLine("La cantidad de resultados pares son :" + impar);
                    Console.ReadLine();
                    showMenuEstadisticas();
                    break;
                case 9:
                    showMenuPrincipal();
                    break;

            }
        }

        public void numeroMasTirado()
        {
            Console.WriteLine("El numero mas tirado");
            _orderedByTiro = numeros.OrderByDescending(p => p.Veces);
            List<Numero> list = _orderedByTiro.Take(1).ToList();
            foreach (Numero item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public void numeroMenosTirado()
        {
            Console.WriteLine("El numero menos tirado");
            _orderedByTiro = numeros.OrderBy(p => p.Veces);
            List<Numero> list = _orderedByTiro.Take(1).ToList();
            foreach (Numero item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public void apostarcolor()
        {
            int ruleta = girarRuleta();
            string color = EscogerColor();
            int apostar = cantidadApostar();
            string colorganador = "";
            int balance = jugador.Dinero;
            balance = balance - apostar;
            jugador.Dinero = balance;
            tiroActual++;
            if (ruleta % 2 == 0)
            {
                par++;
            }
            else
            {
                impar++;
            }
            if (red.List.Contains(ruleta.ToString()))
            {
                rojos++;
                colorganador = "rojo";
            }
            if (black.List.Contains(ruleta.ToString()))
            {
                negros++;
                colorganador = "negro";
            }
            if (colorganador.Contains(color))
            {
                balance = balance + (apostar * 5);
                jugador.Dinero = balance;
                Tiros tiro = new Tiros(tiroActual, ruleta, apostar, "ganado", "Apuesta por color");
                _tiros.Add(tiro);
                Console.WriteLine("Ha ganado la apuesta");
                Console.ReadLine();
            }
            else
            {
                Tiros tiro = new Tiros(tiroActual, ruleta, apostar, "perdido", "Apuesta por color");
                _tiros.Add(tiro);
                Console.WriteLine("Ha perdido la apuesta");
                Console.ReadLine();
            }
        }

        public string EscogerParImpar()
        {
            string regresar = "";
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Escoga un color");
                Console.WriteLine("1.- Par");
                Console.WriteLine("2.- Impar");


            } while (!validaMenu(3, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {
                case 1:
                    regresar = "par";
                    break;
                case 2:
                    regresar = "impar";
                    break;


            }
            return regresar;
        }

        public string EscogerColor()
        {
            string regresar = "";
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Escoga un color");
                Console.WriteLine("1.- Rojo");
                Console.WriteLine("2.- Negro");
              

            } while (!validaMenu(3, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {
                case 1:
                    regresar = "rojo";
                    break;
                case 2:
                    regresar = "negro";
                    break;
            }
            return regresar;
        }
        public int numeroApostar()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el numero por el cual quiere apostar");
            Boolean value = false;
            int regresar=-1;
            while (value == false)
            {
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("Ingrese valor entero del 0 al 36");
                }
                else
                {
                    if(num<0 || num > 36)
                    {
                        Console.WriteLine("Ingrese valor entero del 0 al 36");
                    }
                    else
                    {
                        value = true;
                        regresar = num;
                    }
                }
            }
            return regresar;
        }

        public int cantidadApostar()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la cantidad a apostar");
            Boolean value = false;
            int regresar = 0;
            while (value == false)
            {
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("Ingrese entero valido");
                }
                else
                {
                    if (num % 10 != 0)
                    {
                        Console.WriteLine("Ingrese multiplo de 10");
                    }
                    else
                    {
                        if (num > jugador.Dinero)
                        {
                            Console.WriteLine("No tiene el balance suficiente");
                        }
                        else
                        {
                            value = true;
                            regresar = num;
                        }
                    }
                }

            }
            return regresar;

        }

        public void apostarNumeroEspecifico()
        {
            int num=numeroApostar();
            int apostar=cantidadApostar();
            int ruleta=girarRuleta();
            Console.Clear();
            int balance = jugador.Dinero;
            balance = balance - apostar;
            jugador.Dinero = balance;
            tiroActual++;
            if (ruleta % 2 == 0)
            {
                par++;
            }
            else
            {
                impar++;
            }
            if (black.List.Contains(ruleta.ToString()))
            {
                negros++;
            }
            if (red.List.Contains(ruleta.ToString()))
            {
                rojos++;
            }
            if (num == ruleta)
            {
                balance = balance + (apostar*10);
                jugador.Dinero = balance;
                Tiros tiro = new Tiros(tiroActual, ruleta, apostar, "ganado", "Numero Especifico");
                _tiros.Add(tiro);
                Console.WriteLine("Ha ganado la apuesta");
                Console.ReadLine();

            }
            else
            {
                Tiros tiro = new Tiros(tiroActual, ruleta, apostar, "perdido", "Numero Especifico");
                _tiros.Add(tiro);
                Console.WriteLine("Ha perdido la apuesta");
                Console.ReadLine();
            }
            
            

        }

        public int girarRuleta()
        {
            var random = new Random();
            int value = random.Next(0, 37);
            Numero? numeroBuscar = numeros.FirstOrDefault(u => u.Id==value);
            if (numeroBuscar == null)
            {
               
                Numero agregar = new Numero(value, 1);
                numeros.Add(agregar);
                
            }
            else
            {
                int cant = numeroBuscar.Veces;
                cant = cant + 1;
                numeroBuscar.Veces = cant;
            }
            return value;
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
