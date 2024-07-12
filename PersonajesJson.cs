using System.Text.Json;

public class PersonajeJson{
    public static void GuardarPersonajeJson(List<Personaje> personajes , string nombreArchivo){
        string PersonajesJson= JsonSerializer.Serialize(personajes);
        File.WriteAllText(nombreArchivo,PersonajesJson);
    }

    public static bool Existe( string nombreArchivo){
        return File.Exists(nombreArchivo);
    }

    public static List<Personaje> LeerPersonajesJson(string nombreArchivo){
        var listado = new List<Personaje>();
        string JsonATxt = File.ReadAllText(nombreArchivo);
        listado = JsonSerializer.Deserialize<List <Personaje>>(JsonATxt);
        return listado;
    }
}