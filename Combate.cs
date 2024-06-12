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

    public void iniciar()
    {

        Console.WriteLine($"El combate se llevara a cabo en la arena {arena}");
        while (jugador_1.Salud > 0 && jugador_2.Salud > 0)
        {
            Turno(jugador_1, jugador_2);
            if (jugador_2.Salud <= 0) break;
            Turno(jugador_2, jugador_1);
        }
        if (jugador_1.Salud > 0)
        {
            Console.WriteLine($"{jugador_1.Nombre} es el ganador!");
        }
        else
        {
            Console.WriteLine($"{jugador_2.Nombre} es el ganador!");
        }
    }
    public void Turno(Personaje atacante, Personaje defensor)
    {
        int opcion ; 
        Console.WriteLine($"{atacante.Nombre}'s turno.");
        Console.WriteLine("1. Atacar");
        Console.WriteLine("2. Usar Habilidad");

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
                Console.WriteLine("Seleccione una habilidad:");
                for (int i = 0; i < atacante.Habilidades.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {atacante.Habilidades[i].Nombre}");
                }
                int habilidadSeleccionada = int.Parse(Console.ReadLine()) - 1;
                atacante.usarHabilidad(atacante.Habilidades[habilidadSeleccionada], defensor, arena);
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
        }
    }
}