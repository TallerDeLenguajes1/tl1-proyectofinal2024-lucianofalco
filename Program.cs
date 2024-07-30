using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Menu();
    }

    public static void Menu()
    {
        GestorDeBatallas gestor = new GestorDeBatallas();
        int opcion = 0;
        List<Personaje> personajes;
        Console.WriteLine(ArteAscii.Logo());
        while (opcion != 4)
        {

            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, introduce un número válido.");
            }

            switch (opcion)
            {
                case 1:
                    int nroJugadores = NroJugadores();
                    gestor.CargarJuego("Personajes.json", nroJugadores);
                    gestor.Inicio();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 2:
                    personajes = PersonajeJson.LeerPersonajesJson("Personajes.json");
                    foreach (var personaje in personajes)
                    {
                        personaje.MostrarPersonaje();
                    }
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 3:
                    personajes = PersonajeJson.LeerPersonajesJson("Historial.json");
                    foreach (var personaje in personajes)
                    {
                        personaje.MostrarPersonaje();
                    }
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }

    private static int NroJugadores()
    {
        int opcion = -1;
        int nro = 0;

        while (opcion != 0)
        {
            Console.WriteLine(ArteAscii.Players());
            Console.WriteLine("Seleccione la cantidad de jugadores:");
            Console.WriteLine("(1). DOS JUGADORES");
            Console.WriteLine("(2). CUATRO JUGADORES");
            Console.WriteLine("(3). OCHO JUGADORES");
            Console.WriteLine("(4). DIECISEIS JUGADORES");
            Console.WriteLine("(5). TREINTA Y DOS JUGADORES");
            Console.WriteLine("(0). VOLVER AL MENU PRINCIPAL");

            while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion < 0 || opcion > 5))
            {
                Console.WriteLine("Por favor, introduce un número válido entre 0 y 5.");
            }

            switch (opcion)
            {
                case 1:
                    nro = 2;
                    return nro;
                case 2:
                    nro = 4;
                    return nro;
                case 3:
                    nro = 8;
                    return nro;
                case 4:
                    nro = 16;
                    return nro;
                case 5:
                    nro = 32;
                    return nro;
                case 0:
                    return 0;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        return nro;
    }
}