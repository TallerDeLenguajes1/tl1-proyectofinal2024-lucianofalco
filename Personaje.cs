public class Personaje{
    string nombre;
    string apodo;
    TipoPersonaje tipo ;
    DateTime fechaDeNacimiento ;
    int nivel ; 
    double ataque;
    int velocidad ; 
    double defensa ; 
    double salud ;
    private List<Habilidad> habilidades;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public double Ataque { get => ataque; set => ataque = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public double Defensa { get => defensa; set => defensa = value; }
    public double Salud { get => salud; set => salud = value; }
    public List<Habilidad> Habilidades { get => habilidades; set => habilidades = value; }

    public Personaje(string nombre, string apodo, TipoPersonaje tipo, DateTime fechaDeNacimiento, int nivel, int ataque, int velocidad, int defensa, int salud, List<Habilidad> habilidades)
    {
        this.nombre = nombre;
        this.apodo = apodo;
        this.tipo = tipo;
        this.fechaDeNacimiento = fechaDeNacimiento;
        this.nivel = nivel;
        this.ataque = ataque;
        this.velocidad = velocidad;
        this.defensa = defensa;
        this.salud = salud;
        this.habilidades = habilidades;
    }

    public void Atacar(Personaje objetivo , Arena arena){
        double dañoBase = ataque;
    
    // Ventajas y desventajas elementales
    if (tipo == TipoPersonaje.VOLADOR && objetivo.tipo == TipoPersonaje.TERRESTRE ||
        tipo == TipoPersonaje.TERRESTRE && objetivo.tipo == TipoPersonaje.ACUATICA ||
        tipo == TipoPersonaje.ACUATICA && objetivo.tipo == TipoPersonaje.FUEGO ||
        tipo == TipoPersonaje.FUEGO && objetivo.tipo == TipoPersonaje.VOLADOR)
    {
        dañoBase = dañoBase * 1.2; // Ventaja del 20%
        Console.WriteLine($"{Nombre} tiene ventaja elemental sobre {objetivo.Nombre}!");
    }
    else if (tipo == TipoPersonaje.VOLADOR && objetivo.tipo == TipoPersonaje.ACUATICA ||
             tipo == TipoPersonaje.TERRESTRE && objetivo.tipo == TipoPersonaje.VOLADOR ||
             tipo == TipoPersonaje.ACUATICA && objetivo.tipo == TipoPersonaje.TERRESTRE ||
             tipo == TipoPersonaje.FUEGO && objetivo.tipo == TipoPersonaje.ACUATICA)
    {
        dañoBase = (int)(dañoBase * 0.8); // Desventaja del 20%
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

    Console.WriteLine($"{Nombre} ataca a {objetivo.Nombre} y causa {dañoBase} de daño.");
    objetivo.Salud -= dañoBase;
}
    
    public void usarHabilidad(Habilidad habilidad , Personaje objetivo ,Arena arena ){
        double danioBase = habilidad.Danio;
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

        Console.WriteLine($"{Nombre} usa {habilidad.Nombre} en {objetivo.Nombre} y causa {danioBase} de daño.");
        objetivo.Salud -= danioBase;
    }

}