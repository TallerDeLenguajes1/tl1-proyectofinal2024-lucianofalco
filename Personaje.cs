public class Personaje
{
    string nombre;
    TipoPersonaje tipo;
    DateTime fechaDeNacimiento;
    int nivel;
    double destreza;
    double armadura;
    double ataque;
    int velocidad;
    double salud;

    double efectividad;
    private HabilidadEspecial habilidadEspecial;

    public string Nombre { get => nombre; set => nombre = value; }
    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public double Destreza { get => destreza; set => destreza = value; }
    public double Armadura { get => armadura; set => armadura = value; }
    public double Ataque { get => ataque; set => ataque = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public double Salud { get => salud; set => salud = value; }
    public double Efectividad { get => efectividad; set => efectividad = value; }
    public HabilidadEspecial HabilidadEspecial { get => habilidadEspecial; set => habilidadEspecial = value; }

    public Personaje()
    {
    }

    public Personaje(string nombre, TipoPersonaje tipo, DateTime fechaDeNacimiento, int nivel, double destreza, double armadura, double ataque, int velocidad, double salud, double efectividad, HabilidadEspecial habilidadEspecial)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.fechaDeNacimiento = fechaDeNacimiento;
        this.nivel = nivel;
        this.destreza = destreza;
        this.armadura = armadura;
        this.ataque = ataque;
        this.velocidad = velocidad;
        this.salud = salud;
        this.efectividad = efectividad;
        this.habilidadEspecial = habilidadEspecial;
    }

    public void Atacar(Personaje objetivo, Arena arena)
    {
        double dañoBase = Destreza * Ataque * Nivel * Efectividad;


        // Ventajas y desventajas elementales
        if (Tipo == TipoPersonaje.VOLADOR && objetivo.Tipo == TipoPersonaje.TERRESTRE ||
            Tipo == TipoPersonaje.TERRESTRE && objetivo.Tipo == TipoPersonaje.ACUATICA ||
            Tipo == TipoPersonaje.ACUATICA && objetivo.Tipo == TipoPersonaje.FUEGO ||
            Tipo == TipoPersonaje.FUEGO && objetivo.Tipo == TipoPersonaje.VOLADOR)
        {
            dañoBase = dañoBase * 1.2; // Ventaja del 20%
            Console.WriteLine($"{Nombre} tiene ventaja elemental sobre {objetivo.Nombre}!");
        }
        else if (Tipo == TipoPersonaje.VOLADOR && objetivo.Tipo == TipoPersonaje.ACUATICA ||
                 Tipo == TipoPersonaje.TERRESTRE && objetivo.Tipo == TipoPersonaje.VOLADOR ||
                 Tipo == TipoPersonaje.ACUATICA && objetivo.Tipo == TipoPersonaje.TERRESTRE ||
                 Tipo == TipoPersonaje.FUEGO && objetivo.Tipo == TipoPersonaje.ACUATICA)
        {
            dañoBase = dañoBase * 0.8; // Desventaja del 20%
            Console.WriteLine($"{Nombre} tiene desventaja elemental sobre {objetivo.Nombre}.");
        }

        if (arena.TipoBeneficiado == Tipo)
        {
            dañoBase = (int)(dañoBase * 1.2); // Beneficio del 20%
            Console.WriteLine($"{Nombre} recibe un beneficio de la arena!");
        }
        else if (arena.TipoPerjudiciado == Tipo)
        {
            dañoBase = (int)(dañoBase * 0.8); // Perjuicio del 20%
            Console.WriteLine($"{Nombre} recibe un perjuicio de la arena!");
        }

        double dañoFinal = dañoBase * (100.0 / (100.0 + objetivo.Armadura * objetivo.Velocidad));
        Console.WriteLine($"{Nombre} ataca a {objetivo.Nombre} y causa {dañoBase} de daño.");
        objetivo.Salud -= dañoFinal;
    }


    public void usarHabilidad(HabilidadEspecial habilidad, Personaje objetivo, Arena arena)
    {
        //double danioBase = habilidad.Danio;
        double danioBase = Destreza * habilidad.Danio * Nivel * Efectividad;
        if (arena.TipoBeneficiado == Tipo)
        {
            danioBase = danioBase * 1.2; // Beneficio del 20%
            Console.WriteLine($"{Nombre} recibe un beneficio de la arena!");
        }
        else if (arena.TipoPerjudiciado == Tipo)
        {
            danioBase = danioBase * 0.8; // Perjuicio del 20%
            Console.WriteLine($"{Nombre} recibe un perjuicio de la arena!");
        }

        if (habilidad.Tipo == TipoPersonaje.VOLADOR && objetivo.Tipo == TipoPersonaje.TERRESTRE ||
        habilidad.Tipo == TipoPersonaje.TERRESTRE && objetivo.Tipo == TipoPersonaje.ACUATICA ||
        habilidad.Tipo == TipoPersonaje.ACUATICA && objetivo.Tipo == TipoPersonaje.FUEGO ||
        habilidad.Tipo == TipoPersonaje.FUEGO && objetivo.Tipo == TipoPersonaje.VOLADOR)
        {
            danioBase = danioBase * 1.2; // Ventaja del 20%
            Console.WriteLine($"{Nombre} tiene ventaja elemental sobre {objetivo.Nombre}!");
        }
        else if (habilidad.Tipo == TipoPersonaje.VOLADOR && objetivo.Tipo == TipoPersonaje.ACUATICA ||
                 habilidad.Tipo == TipoPersonaje.TERRESTRE && objetivo.Tipo == TipoPersonaje.VOLADOR ||
                 habilidad.Tipo == TipoPersonaje.ACUATICA && objetivo.Tipo == TipoPersonaje.TERRESTRE ||
                 habilidad.Tipo == TipoPersonaje.FUEGO && objetivo.Tipo == TipoPersonaje.ACUATICA)
        {
            danioBase = danioBase * 0.8; // Desventaja del 20%
            Console.WriteLine($"{Nombre} tiene desventaja elemental sobre {objetivo.Nombre}.");
        }

        Console.WriteLine($"{Nombre} usa {habilidad.Nombre} en {objetivo.Nombre} y causa {danioBase} de daño.");
        objetivo.Salud -= danioBase;
    }

    public void MostrarPersonaje()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Nivel: {Nivel}");
        Console.WriteLine($"Ataque: {Ataque}");
        Console.WriteLine($"Armadura: {Armadura}");
        Console.WriteLine($"Destreza: {Destreza}");
        Console.WriteLine($"Velocidad: {Velocidad}");
        Console.WriteLine($"Tipo: {Tipo}");
        Console.WriteLine($"Salud: {Salud}");
        Console.WriteLine($"Fecha de Nacimiento: {FechaDeNacimiento.ToShortDateString()}");
        Console.WriteLine($"Habilidades: {HabilidadEspecial.Nombre}");
    }

}