using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class HistorialJson
{
    public static void GuardarGanador(Personaje ganador, string nombreArchivo)
{
    try
    {
        List<Personaje> ganadores;

        // Si el archivo existe, leer el contenido actual
        if (File.Exists(nombreArchivo))
        {
            string json = File.ReadAllText(nombreArchivo);

            // Verifico si el contenido del archivo no está vacío o nulo
            if (!string.IsNullOrEmpty(json))
            {
                // Si el contenido no está vacío, deserializamos el JSON a una lista de Personajes
                ganadores = JsonSerializer.Deserialize<List<Personaje>>(json);
            }
            else
            {
                // Si el contenido está vacío, inicializamos una nueva lista de Personajes
                ganadores = new List<Personaje>();
            }
        }
        else
        {
            // Si el archivo no existe, inicializamos una nueva lista de Personajes
            ganadores = new List<Personaje>();
        }

        // Agregamos el ganador a la lista
        ganadores.Add(ganador);

        // Serializamos la lista completa de ganadores y escribimos en el archivo
        string nuevoJson = JsonSerializer.Serialize(ganadores);
        File.WriteAllText(nombreArchivo, nuevoJson);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al guardar el ganador: {ex.Message}");
    }
}

    public static List<Personaje> LeerGanadores(string nombreArchivo)
{
    try
    {
        if (!File.Exists(nombreArchivo))
        {
            return new List<Personaje>();
        }

        string json = File.ReadAllText(nombreArchivo);

        // Verifico si el contenido del archivo no está vacío o nulo
        if (!string.IsNullOrEmpty(json))
        {
            // Si el contenido no está vacío, deserializamos el JSON a una lista de Personajes
            return JsonSerializer.Deserialize<List<Personaje>>(json);
        }
        else
        {
            // Si el contenido está vacío, devuelvo una nueva lista vacía
            return new List<Personaje>();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al leer los ganadores: {ex.Message}");
        return new List<Personaje>();
    }
}

    public static bool Existe(string nombreArchivo)
    {
        return File.Exists(nombreArchivo);
    }
}