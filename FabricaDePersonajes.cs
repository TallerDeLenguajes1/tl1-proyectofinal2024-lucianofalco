public class FabricaDePersonajes
{
    private Random random = new Random();
    List<Personaje> personajes = new List<Personaje>() ;
    Personaje personaje = new Personaje();
    List<HabilidadEspecial> habilidades = new List<HabilidadEspecial>();
    public Personaje crearPersonajeAleatorio(){
        personaje.Ataque = random.Next(1,11);
        personaje.Armadura = random.Next(1,11);
        personaje.Destreza = random.Next(1,6);
        personaje.Nivel = random.Next(1,6);
        personaje.Salud = 100;
        personaje.Efectividad = random.Next(1,6);
        personaje.Velocidad = random.Next(1,11);
        personaje.Tipo = (TipoPersonaje)random.Next(Enum.GetNames(typeof(TipoPersonaje)).Length);
        personaje.HabilidadEspecial = GenerarHabilidadAleatoria();
        personaje.Nombre = GenerarNombreAleatorios();
        personaje.FechaDeNacimiento = GenerarFechaDeNacimientoAleatoria();
        personajes.Add(personaje);
        return personaje;
    }

    //public HabilidadEspecial(string nombre, int danio, TipoPersonaje tipo)

    private HabilidadEspecial GenerarHabilidadAleatoria()
    {
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

    private string GenerarNombreAleatorios()
    {
        string[] nombres = { "Aiden", "Blaze", "Kai", "Luna", "Nix", "Orion", "Phoenix", "Sage", "Titan", "Zephyr"};

        string nombre = nombres[random.Next(nombres.Length)];
        
        return nombre;
    }

    private DateTime GenerarFechaDeNacimientoAleatoria()
    {
        DateTime start = new DateTime(1924, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(random.Next(range));
    }
    
}