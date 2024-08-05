public class AdministradorDeBatallas
{
    private FabricaDePersonajes fabrica = new FabricaDePersonajes();
    private List<Personaje> combatientes = new List<Personaje>();
    private List<Personaje> ganadores = new List<Personaje>();

    public AdministradorDeBatallas()
    {

    }

    public void CargarJuego(string NombreJson, int cantidad)
    {
        combatientes.Clear();
        var nombresUsados = new List<string>();
        Console.WriteLine("Combatientes: ");
        for (int i = 0; i < cantidad; i++)
        {
            Personaje personaje;
            do
            {
                personaje = fabrica.CrearPersonajeAleatorio();
            } while (nombresUsados.Contains(personaje.Nombre));
            nombresUsados.Add(personaje.Nombre);
            MensajesUI mensaje = new MensajesUI();
            Console.WriteLine("___________________________________________________________");
            mensaje.ShowPersonaje(personaje);
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine();
            combatientes.Add(personaje);
        }
        PersonajeJson.GuardarPersonajeJson(combatientes, NombreJson);
    }

    public void Inicio()
    {
        while (combatientes.Count > 1)
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            switch (combatientes.Count)
            {
                case 2:
                    Console.WriteLine(ArteAscii.Final);
                    break;
                case 4:
                    Console.WriteLine(ArteAscii.SemiFinal);
                    break;
                case 8:
                    Console.WriteLine(ArteAscii.CuartosFinal);
                    break;
                case 16: 
                    Console.WriteLine(ArteAscii.OctavosFinal);
                    break ;
                case 32:
                    Console.WriteLine(ArteAscii.RondaPreliminar);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            mecanica();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ArteAscii.ganador);
        Console.WriteLine($"El ganador final es {combatientes[0].Nombre}");
        Console.ResetColor();
        HistorialJson.GuardarGanador(combatientes[0], "Historial.json");
    }

    private void mecanica()
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
                Personaje ganador = combate.Iniciar();
                ganadores.Add(ganador);
            }
            else
            {
                ganadores.Add(combatientes[i]);
            }
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
        }
        combatientes = new List<Personaje>(ganadores);
    }
}