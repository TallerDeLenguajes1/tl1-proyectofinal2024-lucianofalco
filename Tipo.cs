using System.Security.Cryptography;


public enum TipoPersonaje
{
    TERRESTRE = 1 , //Ventaja contra Acuático. Desventajas: Desventaja contra Volador.
    VOLADOR = 2, //Ventajas: Ventaja contra Tierra. Desventajas: Desventaja contra Acuático. ,
    ACUATICA = 3 , //Ventajas: Ventaja contra Fuego.Desventajas: Desventaja contra Tierra.
    FUEGO = 4 //Ventajas: Ventaja contra Volador.Desventajas: Desventaja contra Acuático.
}


/*
Arenas

Arena Volcánica
Beneficio: Aumenta el poder de los ataques de Fuego.
Perjuicio: Reduce la efectividad de los ataques de Acuático.

Bosque Encantado
Beneficio: Aumenta la evasión de los personajes Voladores.
Perjuicio: Reduce la defensa de los personajes de Tierra.

Océano Profundo
Beneficio: Aumenta la regeneración de salud de los personajes Acuáticos.
Perjuicio: Aumenta la vulnerabilidad al daño de los personajes de Fuego.

Caverna Rocosa
Beneficio: Aumenta la defensa de los personajes de Tierra.
Perjuicio: Reduce la velocidad de los personajes Voladores.*/
public enum TipoArena
{
    VOLCANICA = 1, //Beneficio: Aumenta el poder de los ataques de Fuego.Perjuicio: Reduce la efectividad de los ataques de Acuático.
    BOSQUE = 2 , //Beneficio: Aumenta el poder de los ataques de Fuego.Perjuicio: Reduce la efectividad de los ataques de Acuático.
    OCEANO = 3 , //Beneficio: Aumenta la regeneración de salud de los personajes Acuáticos.Perjuicio: Aumenta la vulnerabilidad al daño de los personajes de Fuego.
    CAVERNA = 4 , //Beneficio: Aumenta la defensa de los personajes de Tierra.Perjuicio: Reduce la velocidad de los personajes Voladores.

}