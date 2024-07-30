using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class PersonajeJson
{
    // Método para guardar la lista de personajes en un archivo JSON
    public static void GuardarPersonajeJson(List<Personaje> personajes, string nombreArchivo)
    {
        try
        {
            string personajesJson = JsonSerializer.Serialize(personajes);
            File.WriteAllText(nombreArchivo, personajesJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar los personajes en el archivo JSON: {ex.Message}");
        }
    }

    // Método para verificar si el archivo existe
    public static bool Existe(string nombreArchivo)
    {
        return File.Exists(nombreArchivo);
    }

    // Método para leer la lista de personajes desde un archivo JSON
    public static List<Personaje> LeerPersonajesJson(string nombreArchivo)
    {
        var listado = new List<Personaje>();

        try
        {
            if (File.Exists(nombreArchivo))
            {
                string jsonATxt = File.ReadAllText(nombreArchivo);

                // Verificación del contenido del archivo
                if (!string.IsNullOrEmpty(jsonATxt))
                {
                    listado = JsonSerializer.Deserialize<List<Personaje>>(jsonATxt);
                }
                else
                {
                    Console.WriteLine("El archivo JSON está vacío.");
                }
            }
            else
            {
                Console.WriteLine("El archivo JSON no existe.");
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
        }

        return listado;
    }
}