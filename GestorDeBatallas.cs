public class GestorDeBatallas
{
    private FabricaDePersonajes fabrica;
    private List<Personaje> combatientes = new List<Personaje>();
    private List<Personaje> ganadores = new List<Personaje>();
    private List<Personaje> Perdedores = new List<Personaje>();
    private Random random = new Random();

    public GestorDeBatallas()
    {
        fabrica = new FabricaDePersonajes();
    }

    public void CargarJuego(string NombreJson, int cantidad)
    {
        combatientes = new List<Personaje>();
        for (int i = 0; i < cantidad; i++)
        {
            Personaje personaje;
            do
            {
                personaje = fabrica.CrearPersonajeAleatorio();
            } while (combatientes.Contains(personaje));
            combatientes.Add(personaje);
        }
        PersonajeJson.GuardarPersonajeJson(combatientes, NombreJson); // guardo la lista en .json
        Console.Clear();
    }

    public void Inicio()
    {
        while (combatientes.Count > 1)
        {
            Console.WriteLine("----------- Nueva ronda -----------");
            Console.WriteLine("------Combatientes actuales--------");

            // Muestra los combatientes actuales
            foreach (var combatiente in combatientes)
            {
                combatiente.MostrarPersonaje();
                Console.WriteLine("-------------------------");
            }

            Console.WriteLine();

            ganadores.Clear();
            for (int i = 0; i < combatientes.Count; i += 2)
            {
                if (i + 1 < combatientes.Count)
                {
                    Personaje jugador1 = combatientes[i];
                    Personaje jugador2 = combatientes[i + 1];
                    Arena arena = Arena.GenerarArenaAleatoria();

                    Combate combate = new Combate(jugador1, jugador2, arena);
                    Personaje ganador = combate.iniciar();
                    ganador.Salud += 20;
                    ganadores.Add(ganador);
                    HistorialJson.GuardarGanador(ganador , "Historial.json");
                }
                else
                {
                    ganadores.Add(combatientes[i]);
                }
            }

            Console.WriteLine("\n--- Resultados de la ronda ---");
            foreach (var ganador in ganadores)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{ganador.Nombre} pasa a la siguiente ronda.");
                Console.ResetColor();
            }

            foreach (var perdedor in combatientes.Except(ganadores))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{perdedor.Nombre} ha sido eliminado.");
                Perdedores.Add(perdedor);
                Console.ResetColor();
            }

            combatientes = new List<Personaje>(ganadores);
            Console.WriteLine("-----------------------------------");
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("***********************************************");
        Console.WriteLine($"***El ganador final es {combatientes[0].Nombre}***");
        Console.WriteLine("***********************************************");
        Console.ResetColor();
    }
}