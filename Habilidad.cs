public class Habilidad
{
    string nombre ; 
    int danio ;

    public Habilidad(string nombre, int danio)
    {
        this.nombre = nombre;
        this.danio = danio;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Danio { get => danio; set => danio = value; }
}