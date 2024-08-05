public class Combate
{
    private Personaje jugador1;
    private Personaje jugador2;
    private Arena arena;

    public Combate(Personaje jugador1, Personaje jugador2, Arena arena)
    {
        this.jugador1 = jugador1;
        this.jugador2 = jugador2;
        this.arena = arena;
    }

    public Personaje Iniciar()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.ResetColor();
        while (jugador1.Salud > 0 && jugador2.Salud > 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ArteAscii.CardArena(arena));
            Console.ResetColor();
            Console.WriteLine(ArteAscii.CardPersonaje(jugador1));
            Console.WriteLine("                   vs");
            Console.WriteLine(ArteAscii.CardPersonaje(jugador2));
            Turno(jugador1, jugador2);
            if (jugador2.Salud <= 0) break;
            Turno(jugador2, jugador1);
        }

        if (jugador1.Salud > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Avanza a la siguiente ronda");
            Console.WriteLine(ArteAscii.CardPersonaje(jugador1));
            Console.ResetColor();
            return jugador1;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Avanza a la siguiente ronda");
            Console.WriteLine(ArteAscii.CardPersonaje(jugador2));
            Console.ResetColor();
            return jugador2;
        }
    }

    public void Turno(Personaje atacante, Personaje defensor)
    {
        int opcion;
        Console.WriteLine($"Turno de: {atacante.Nombre}.");
        Console.WriteLine("\t1. Atacar");
        Console.WriteLine("\t2. Usar Habilidad");
        Console.WriteLine("Ingrese el número a operar:");
        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Por favor, introduce un número válido.");
        }

        switch (opcion)
        {
            case 1:
                atacante.Atacar(defensor, arena);
                break;
            case 2:
                atacante.UsarHabilidad(defensor, arena);
                break;
            default:
                Console.WriteLine("Opción no válida, perdiendo turno.");
                break;
        }
    }
}