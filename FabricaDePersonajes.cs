public class FabricaDePersonajes
{
    private static Random random = new Random();
    private static List<string> nombresPokemones;
    private PokeApi pokeApi = new PokeApi();
    private List<Personaje> personajes = new List<Personaje>();    
    public PokeApi PokeApi { get => pokeApi; set => pokeApi = value; }
    public List<string> NombresPokemones { get => nombresPokemones; set => nombresPokemones = value; }
    public List<Personaje> Personajes { get => personajes; set => personajes = value; }

    public FabricaDePersonajes()
    {
        
    }

    public string ObtenerNombre()
    { 
        string url = "https://pokeapi.co/api/v2/pokemon?limit=100";
        nombresPokemones = PokeApi.GetNombresPokemones(url);
        string poke ; 
        poke= nombresPokemones[random.Next(nombresPokemones.Count)];
        return poke;
    }

    public Personaje CrearPersonajeAleatorio(){
        Random rand = new Random();
        Personaje personaje = new Personaje();
        personaje.Ataque = rand.Next(1,11);
        personaje.Armadura = rand.Next(1,11);
        personaje.Destreza = rand.Next(1,6);
        personaje.Nivel = rand.Next(1,6);
        personaje.Salud = 100;
        personaje.Efectividad = rand.Next(1,6);
        personaje.Velocidad = rand.Next(1,11);
        personaje.Tipo = (TipoPersonaje)rand.Next(1,Enum.GetNames(typeof(TipoPersonaje)).Length);
        personaje.HabilidadEspecial = GenerarHabilidadAleatoria();
        personaje.Nombre = ObtenerNombre();
        personaje.FechaDeNacimiento = GenerarFechaDeNacimientoAleatoria();
        Personajes.Add(personaje);
        return personaje;
    }


    private HabilidadEspecial GenerarHabilidadAleatoria()
    {
        Random random = new Random();
        string[] nombres = { "LLamarada", "Trampa de piedras", "tornado", "tsunami"};
        string nombre = nombres[random.Next(nombres.Length)];
        if (nombre == "LLamarada")
        {
            return new HabilidadEspecial(nombre , random.Next(1,11) , TipoPersonaje.FUEGO);
        }
        else if (nombre =="Trampa de piedras")
        {
            return new HabilidadEspecial(nombre , random.Next(1,11) , TipoPersonaje.TERRESTRE);
        }
        else if (nombre == "tornado" )
        {
            return new HabilidadEspecial(nombre , random.Next(1,11) , TipoPersonaje.VOLADOR);
            
        }
        else
        {
            return new HabilidadEspecial(nombre , random.Next(1,11), TipoPersonaje.ACUATICA);
        }
    }



    private DateTime GenerarFechaDeNacimientoAleatoria()
    {
        Random random = new Random();
        DateTime start = new DateTime(1924, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(random.Next(range));
    }
    
}