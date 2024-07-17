//Personaje(string nombre, string apodo, TipoPersonaje tipo, DateTime fechaDeNacimiento, int nivel, int ataque, int velocidad, int defensa, int salud, List<Habilidad> habilidades)
// Ejemplo de personajes
        
public class Program
{
    public static void Main()
    {
        GestorDeBatallas gestor = new GestorDeBatallas();
        gestor.CargarJuego("Personajes.json",8);
        gestor.Inicio();
        Console.ReadLine();

        //falta corregir las rondas, cuartos semi etc y el ganador, no entra al swich
        //realizar una menu principal mostrando el logo del juego con las opciones iniciar , ver personajes
        //otra opcion para ver el historial de ganadores
    }
}