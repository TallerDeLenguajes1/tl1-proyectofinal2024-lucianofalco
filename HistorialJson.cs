using System.Text.Json;

public class HistorialJson {
    public static void GuardarGanador(Personaje ganador, string nombreArchivo)
    {
        List<Personaje> ganadores;

        // Si el archivo existe, leer el contenido actual
        if (File.Exists(nombreArchivo))
        {
            string json = File.ReadAllText(nombreArchivo);
            ganadores = JsonSerializer.Deserialize<List<Personaje>>(json) ;
        }
        else
        {
            ganadores = new List<Personaje>();
        }

        ganadores.Add(ganador);

        // Serializar la lista completa de ganadores y escribirla en el archivo
        string nuevoJson = JsonSerializer.Serialize(ganadores);
        File.WriteAllText(nombreArchivo, nuevoJson);
    }

    public static List<Personaje> LeerGanadores(string nombreArchivo)
    {
        if (!File.Exists(nombreArchivo))
        {
            return new List<Personaje>();
        }

        string json = File.ReadAllText(nombreArchivo);
        return JsonSerializer.Deserialize<List<Personaje>>(json);
    }

    public static bool Existe(string nombreArchivo)
    {
        return File.Exists(nombreArchivo);
    }
}