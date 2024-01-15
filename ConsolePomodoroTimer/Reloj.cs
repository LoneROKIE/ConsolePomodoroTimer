using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace ConsolePomo
{
    public class Reloj
    {
        static void Main()
        { 
            int opcion;
            while (true)
            {
                try
                {
                    // llamamos al menu
                    Menu();
                    Console.Write(">");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Ejecucion(1, 5, 25, 5);
                            break;
                        case 2:
                            Ejecucion(1, 5, 30, 8);
                            break;
                        case 3:
                            Ejecucion(1, 5, 40, 8);
                            break;
                        case 4:
                            Ejecucion(1, 5, 50, 10);
                            break;
                        default:
                            Console.WriteLine("Tecla Equivocada");
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------------------");
                    Console.WriteLine(" Hubo una Excepcion!!");
                    Console.WriteLine("-----------------------");
                    Console.ResetColor();
                }
            }

        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the pomodoro Console timer !!!");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Selecciona una opcion");
            Console.WriteLine("[1]-Trabajo 25 min y 5 ciclos 5 min descanso");
            Console.WriteLine("[2]-Trabajo 30 min y 5 ciclos 8 min descanso");
            Console.WriteLine("[3]-Trabajo 40 min y 5 ciclos 8 min descanso");
            Console.WriteLine("[4]-Trabajo 50 min y 5 ciclos 10 min descanso");
            Console.WriteLine("\t\t\t\t\t\tDigita CTRL + C para salir!!");
            Console.ResetColor();
        }

        static void Ejecucion(int contadorCic, int contadorDesc, int minutosTrab, int minutosDesc)
        {
            SoundPlayer volver = new SoundPlayer("volver.wav");
            SoundPlayer terminado = new SoundPlayer("terminado.wav");

            for (int i = contadorCic; i <= contadorDesc; i++)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");
                // Cambiar color a verde
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ciclos de Trabajo Restantes: " + contadorDesc--);
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------");
                //Console.WriteLine("Ciclos de Descansos Actuales: " + contadorDescansos);
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine("Trabajando....");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------");
                // Cambiar color a verde
                Console.ForegroundColor = ConsoleColor.Green;
                EjecutarTempo(minutosTrab);
                Console.ResetColor();
                terminado.PlayLooping(); // reproduce sonido de terminado
                Console.WriteLine("Presiona cualquier tecla para seguir...");
                Console.ReadLine();
                terminado.Stop();
                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Descansando...");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                EjecutarTempo(minutosDesc);
                Console.ResetColor();
                volver.PlayLooping();
                Console.WriteLine("Presiona cualquier tecla para seguir...");
                Console.ReadLine();
                volver.Stop();
                Console.Clear();
            }
        }

        static void EjecutarTempo(int minutos)
        {
            int segundosTotales = minutos * 60;

            for (int segundos = segundosTotales; segundos > 0; segundos--)
            {
                MostrarTiempoRestante(segundos);
                Thread.Sleep(1000);
            };
            Console.WriteLine();
            Console.WriteLine("Tiempo completado !!!");
        }

        static void MostrarTiempoRestante(int segundos)
        {
            int minutosRestantes = segundos / 60;
            int segundosRestantes = segundos % 60;
            Console.Write($"\rTiempo restante: {minutosRestantes:00}:{segundosRestantes:00}");
        }
    }
}
