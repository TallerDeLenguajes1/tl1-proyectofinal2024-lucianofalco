using System.Net;
using System.Text.Json;

public class PokeApi
{
    public List<string> GetNombresPokemones(string url)
    {
        List<string> nombresPokemones = new List<string>();

        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return nombresPokemones;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var jsonDocument = JsonDocument.Parse(responseBody);
                        var results = jsonDocument.RootElement.GetProperty("results").EnumerateArray();

                        foreach (var result in results)
                        {
                            string name = result.GetProperty("name").GetString();
                            nombresPokemones.Add(name);
                        }
                    }
                }
            }
        }
        catch (WebException ex)
        {
            // Manejar error
            Console.WriteLine($"Error: {ex.Message}");
        }

        return nombresPokemones;
    }
}