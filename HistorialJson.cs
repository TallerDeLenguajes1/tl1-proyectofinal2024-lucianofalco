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

        if (File.Exists(nombreArchivo))
        {
            string json = File.ReadAllText(nombreArchivo);

            if (!string.IsNullOrEmpty(json))
            {
                ganadores = JsonSerializer.Deserialize<List<Personaje>>(json);
            }
            else
            {
                ganadores = new List<Personaje>();
            }
        }
        else
        {
            ganadores = new List<Personaje>();
        }


        ganadores.Add(ganador);

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

        if (!string.IsNullOrEmpty(json))
        {
            return JsonSerializer.Deserialize<List<Personaje>>(json);
        }
        else
        {
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