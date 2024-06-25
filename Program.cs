//Personaje(string nombre, string apodo, TipoPersonaje tipo, DateTime fechaDeNacimiento, int nivel, int ataque, int velocidad, int defensa, int salud, List<Habilidad> habilidades)
// Ejemplo de personajes
        
FabricaDePersonajes fabrica = new FabricaDePersonajes();
        
        // Crear y mostrar información de 5 personajes aleatorios
        for (int i = 0; i < 5; i++)
        {
            Personaje personaje = fabrica.crearPersonajeAleatorio();
            personaje.MostrarPersonaje();
            Console.WriteLine();
        }