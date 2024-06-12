//Personaje(string nombre, string apodo, TipoPersonaje tipo, DateTime fechaDeNacimiento, int nivel, int ataque, int velocidad, int defensa, int salud, List<Habilidad> habilidades)
// Ejemplo de personajes
        var habilidadesFuego = new List<Habilidad> { new Habilidad("Llamarada", 30), new Habilidad("Explosión Ígnea", 40) };
        var personajeFuego = new Personaje("Dragón de Fuego", "Fuego", 100, 20, habilidadesFuego);
        
        var habilidadesAgua = new List<Habilidad> { new Habilidad("Chorro de Agua", 25), new Habilidad("Ola Gigante", 35) };
        var personajeAgua = new Personaje("Sirena Acuática", "Acuático", 100, 20, habilidadesAgua);

        // Ejemplo de arena
        var arena = new Arena("Océano Profundo", "Acuático", "Fuego");

        // Iniciar combate
        var combate = new Combate(personajeFuego, personajeAgua, arena);
        combate.Iniciar();
