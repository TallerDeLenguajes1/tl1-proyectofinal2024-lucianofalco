public class FabricaDePersonajes
{
    private Random random = new Random();
    List<Personaje> personajes = new List<Personaje>() ;

    public Random Random { get => random; set => random = value; }
    public List<Personaje> Personajes { get => personajes; set => personajes = value; }

    public FabricaDePersonajes(Random random, List<Personaje> personajes)
    {
        this.random = random;
        this.personajes = personajes;
    }

    public FabricaDePersonajes()
    {
    }

    public Personaje crearPersonajeAleatorio(){
        Personaje personaje = new Personaje();
        personaje.Ataque = Random.Next(1,11);
        personaje.Armadura = Random.Next(1,11);
        personaje.Destreza = Random.Next(1,6);
        personaje.Nivel = Random.Next(1,6);
        personaje.Salud = 100;
        personaje.Efectividad = Random.Next(1,6);
        personaje.Velocidad = Random.Next(1,11);
        personaje.Tipo = (TipoPersonaje)Random.Next(Enum.GetNames(typeof(TipoPersonaje)).Length);
        personaje.HabilidadEspecial = GenerarHabilidadAleatoria();
        personaje.Nombre = GenerarNombreAleatorio();
        personaje.FechaDeNacimiento = GenerarFechaDeNacimientoAleatoria();
        Personajes.Add(personaje);
        return personaje;
    }


    private HabilidadEspecial GenerarHabilidadAleatoria()
    {
        string[] nombres = { "LLamarada", "Trampa de piedras", "tornado", "tsunami"};
        string nombre = nombres[Random.Next(nombres.Length)];
        if (nombre == "LLamarada")
        {
            return new HabilidadEspecial(nombre , Random.Next(1,11) , TipoPersonaje.FUEGO);
        }
        else if (nombre =="Trampa de piedras")
        {
            return new HabilidadEspecial(nombre , Random.Next(1,11) , TipoPersonaje.TERRESTRE);
        }
        else if (nombre == "tornado" )
        {
            return new HabilidadEspecial(nombre , Random.Next(1,11) , TipoPersonaje.VOLADOR);
            
        }
        else
        {
            return new HabilidadEspecial(nombre , Random.Next(1,11), TipoPersonaje.ACUATICA);
        }
    }

    private string GenerarNombreAleatorio()
    {
        string[] nombres = { "Aiden", "Blaze", "Kai", "Luna", "Nix", "Orion", "Phoenix", "Sage", "Titan", "Zephyr"};

        string nombre = nombres[Random.Next(nombres.Length)];
        
        return nombre;
    }

    private DateTime GenerarFechaDeNacimientoAleatoria()
    {
        DateTime start = new DateTime(1924, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(Random.Next(range));
    }
    
}