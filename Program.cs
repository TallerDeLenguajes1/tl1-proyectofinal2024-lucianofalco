using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        AdministradorDeBatallas gestor = new AdministradorDeBatallas();
        int opcion = 0;
        presentacion();

        while (opcion != 4)
        {
            opcion = IngresarEntero();
            MenuPrincipal(gestor, opcion);
        }
    }

    private static void presentacion()
    {
        Console.WriteLine("Preciona una tecla para iniciar...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m", ArteAscii.presentacion1);
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m", ArteAscii.presentacion2);
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m", ArteAscii.presentacion3);
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m", ArteAscii.presentacion4);
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m", ArteAscii.Logo);
    }

    private static void MenuPrincipal(AdministradorDeBatallas gestor, int opcion)
    {
        switch (opcion)
        {
            case 1:
                CargarJugadores(gestor);
                Menu();
                break;
            case 2:
                leerPersonajes();
                Menu();
                break;
            case 3:

                leerGanadores();
                Menu();
                break;
            case 4:
                SalirDelJuego();
                break;
            default:
                OpcionInvalida();
                Menu();
                break;
        }
    }

    private static int IngresarEntero()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Por favor, introduce un número válido.\n");
        }

        return opcion;
    }

    public static void Menu()
    {
        AdministradorDeBatallas gestor = new AdministradorDeBatallas();
        int opcion = 0;
        Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m",ArteAscii.Logo);
        while (opcion != 4)
        {

            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, introduce un número válido.\n");
            }

            switch (opcion)
            {
                case 1:
                    CargarJugadores(gestor);
                    Menu();
                    break;
                case 2:
    
                    leerPersonajes();
                    Menu();
                    break;
                case 3:
                    leerGanadores();
                    Menu();
                    break;
                case 4:
                    SalirDelJuego();
                    break;
                default:
                    OpcionInvalida();
                    Menu();
                    break;
            }
        }
    }

    private static void OpcionInvalida()
    {
        Console.Clear();
        Console.WriteLine("Opción no válida");
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    private static void leerGanadores()
    {
        Console.Clear();
        List<Personaje> personajes = PersonajeJson.LeerPersonajesJson("Historial.json");
        MensajesUI msj = new MensajesUI();
        foreach (var personaje in personajes)
        {
            msj.ShowPersonaje(personaje);
            Console.WriteLine("====================================================\n");
        }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    private static void leerPersonajes()
    {
        Console.Clear();
        List<Personaje>personajes = PersonajeJson.LeerPersonajesJson("Personajes.json");
        MensajesUI mensaje = new MensajesUI();
        foreach (var personaje in personajes)
        {
            mensaje.ShowPersonaje(personaje);
            Console.WriteLine("====================================================");
        }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    private static void SalirDelJuego()
    {
        Console.Clear();
        MostrarMensajeIA(ArteAscii.documentacion);
        Environment.Exit(0);
    }

    private static void CargarJugadores(AdministradorDeBatallas gestor)
    {
        int nroJugadores = NroJugadores();
        if (nroJugadores != 0)
        {   
        gestor.CargarJuego("Personajes.json", nroJugadores);
        gestor.Inicio();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        }
        else
        {
            ShowMenu();
        }
    }

    private static int NroJugadores()
    {
        int opcion = -1;
        int nro = 0;

        while (opcion != 0)
        {
            Console.WriteLine(ArteAscii.Players);
            ShowMenu();

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
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        return nro;
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Seleccione la cantidad de jugadores:");
        Console.WriteLine("(1). DOS JUGADORES");
        Console.WriteLine("(2). CUATRO JUGADORES");
        Console.WriteLine("(3). OCHO JUGADORES");
        Console.WriteLine("(4). DIECISEIS JUGADORES");
        Console.WriteLine("(5). TREINTA Y DOS JUGADORES");
        Console.WriteLine("(0). VOLVER AL MENU PRINCIPAL");
    }
private static void MostrarMensajeIA(string eliminado)
    {
        foreach (char letra in eliminado)
        {
            Console.Write(letra);
            Thread.Sleep(15);
        }
    }
}

