public class MensajesUI
{
    public void ShowPersonaje(Personaje personaje)
    {
        System.Console.WriteLine(personaje.MostrarPersonaje());
    }
    public void ShowArena(Arena arena)
    {
        System.Console.WriteLine(arena.MostrarArena());
    }
    public void ShowHabilidad(HabilidadEspecial habilidad)
    {
        System.Console.WriteLine(habilidad.MostrarHabilidad());
    }
}