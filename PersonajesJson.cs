using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class PersonajeJson
{
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

    public static bool Existe(string nombreArchivo)
    {
        return File.Exists(nombreArchivo);
    }

    public static List<Personaje> LeerPersonajesJson(string nombreArchivo)
    {
        var listado = new List<Personaje>();

        try
        {
            if (File.Exists(nombreArchivo))
            {
                string jsonATxt = File.ReadAllText(nombreArchivo);

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
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
        }

        return listado;
    }
}