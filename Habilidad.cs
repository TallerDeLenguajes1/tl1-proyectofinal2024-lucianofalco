public class HabilidadEspecial
{
    string nombre ; 
    double danio ;
    TipoPersonaje tipo;

    public HabilidadEspecial(string nombre, double danio, TipoPersonaje tipo)
    {
        this.nombre = nombre;
        this.danio = danio;
        this.tipo = tipo;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public double Danio { get => danio; set => danio = value; }
    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }

    public void MostrarHabilidad(){
        Console.WriteLine($"Habilidad: {Nombre} , Daño {Danio} , Tipo: {tipo}");
    }
}