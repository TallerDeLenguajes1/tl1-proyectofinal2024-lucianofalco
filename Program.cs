//Personaje(string nombre, string apodo, TipoPersonaje tipo, DateTime fechaDeNacimiento, int nivel, int ataque, int velocidad, int defensa, int salud, List<Habilidad> habilidades)
// Ejemplo de personajes
        
public class Program
{
    public static void Main()
    {
        GestorDeBatallas gestor = new GestorDeBatallas();

        gestor.AgregarCombatientes(4); 

        gestor.Inicio();

        Console.ReadLine();
    }
}