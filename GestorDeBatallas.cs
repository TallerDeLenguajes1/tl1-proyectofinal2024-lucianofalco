using System.Collections;

public class GestorDeBatallas
{
    private FabricaDePersonajes fabrica;
    private List<Personaje> combatientes = new List<Personaje>();
    private List<Personaje> ganadores = new List<Personaje>();

    public GestorDeBatallas()
    {
        fabrica = new FabricaDePersonajes();
    }

    public void CargarJuego(string NombreJson, int cantidad)
    {
        combatientes = new List<Personaje>();
        var nombreUsados = new List<string>() ;
        Console.WriteLine("Combatientes: ");
        for (int i = 0; i < cantidad; i++)
        {
            Personaje personaje;
            do
            {
                personaje = fabrica.CrearPersonajeAleatorio();
            } while (nombreUsados.Contains(personaje.Nombre));
            nombreUsados.Add(personaje.Nombre);
            Console.WriteLine("___________________________________________________________");
            personaje.MostrarPersonaje();
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine();

            combatientes.Add(personaje);
        }
        PersonajeJson.GuardarPersonajeJson(combatientes, NombreJson); // guardo la lista en .json
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    public void Inicio()
    {
        switch (combatientes.Count)
        {
            case 2:
                ArteAscii.SemiFinal();
                break;
            case 4:
                ArteAscii.CuartosFinal();
                break;
            case 8:
                ArteAscii.OctavosFinal();
                break;
            case 16:
                ArteAscii.RondaPreliminar();
                break;
            case 32:
                ArteAscii.RondaPreliminar();
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }
        mecanica();
        Console.ForegroundColor = ConsoleColor.Green;
        ArteAscii.ganador();
        Console.WriteLine($"El ganador final es {combatientes[0].Nombre}");
        Console.ResetColor();
    }

    private void mecanica()
    {
        while (combatientes.Count > 1)
        {
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
                    HistorialJson.GuardarGanador(ganador, "Historial.json");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    ganadores.Add(combatientes[i]);
                }
            }
            combatientes = new List<Personaje>(ganadores);
        }
    }
}