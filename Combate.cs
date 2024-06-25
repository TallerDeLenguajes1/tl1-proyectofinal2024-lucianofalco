public class Combate
{
    private Personaje jugador_1;
    private Personaje jugador_2;
    private Arena arena;

    public Combate(Personaje jugador_1, Personaje jugador_2, Arena arena)
    {
        this.jugador_1 = jugador_1;
        this.jugador_2 = jugador_2;
        this.arena = arena;
    }

    public Personaje iniciar()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"El combate se llevara a cabo en la arena {arena.Nombre}");
        Console.WriteLine($"--------------------------------datos del combatiente {jugador_1.Nombre}-------------------------------------");
                jugador_1.MostrarPersonaje();
                Console.WriteLine($"--------------------------------------------------------------------");
                Console.WriteLine($"--------------------------------datos del combatiente {jugador_2.Nombre}-------------------------------------");
                jugador_2.MostrarPersonaje();
                Console.WriteLine($"--------------------------------------------------------------------");
        Console.ResetColor();
        while (jugador_1.Salud > 0 && jugador_2.Salud > 0)
        {
            Turno(jugador_1, jugador_2);
            if (jugador_2.Salud <= 0) break;
            Turno(jugador_2, jugador_1);
        }
        if (jugador_1.Salud > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"******************{jugador_1.Nombre} es el ganador!****************");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"******************{jugador_2.Nombre} Pierde!****************");
            Console.ResetColor();
            return jugador_1;

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"******************{jugador_2.Nombre} es el ganador!****************");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"******************{jugador_1.Nombre} Pierde!****************");
            Console.ResetColor();
            return jugador_2;
        }
    }
    public void Turno(Personaje atacante, Personaje defensor)
    {
        int opcion ; 
        Console.WriteLine();
        Console.WriteLine($"Turno de: {atacante.Nombre}'.");
        Console.WriteLine("\t1. Atacar");
        Console.WriteLine("\t2. Usar Habilidad");

        Console.WriteLine("Ingrese el numero a operar");
        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Por favor, introduce un número válido.");
            continue;
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

        if (defensor.Salud > 0)
        {
            Console.WriteLine($"{defensor.Nombre} tiene {defensor.Salud} de salud restante.");
        }
        else
        {
            Console.WriteLine($"{defensor.Nombre} ha sido derrotado.");
            Console.WriteLine();
        }
    }
}