public class Arena
{
    private string nombre;
    private TipoPersonaje tipoBeneficiado;
    private TipoPersonaje tipoPerjudiciado;

    public Arena(string nombre, TipoPersonaje tipoBeneficiado, TipoPersonaje tipoPerjudiciado)
    {
        this.nombre = nombre;
        this.tipoBeneficiado = tipoBeneficiado;
        this.tipoPerjudiciado = tipoPerjudiciado;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public TipoPersonaje TipoBeneficiado { get => tipoBeneficiado; set => tipoBeneficiado = value; }
    public TipoPersonaje TipoPerjudiciado { get => tipoPerjudiciado; set => tipoPerjudiciado = value; }

    public static Arena GenerarArenaAleatoria()
{
    Random random = new Random();

    string[] nombres = { "Arena Volcánica", "Bosque Encantado", "Océano Profundo", "Caverna Rocosa" };

    TipoPersonaje[] tiposBeneficiados = { TipoPersonaje.FUEGO, TipoPersonaje.VOLADOR, TipoPersonaje.ACUATICA, TipoPersonaje.TERRESTRE };

    int indiceArena = random.Next(nombres.Length);

    string nombre = nombres[indiceArena];
    TipoPersonaje tipoBeneficiado = tiposBeneficiados[indiceArena];

    TipoPersonaje tipoPerjudicado;
    switch (nombre)
    {
        case "Arena Volcánica":
            tipoPerjudicado = TipoPersonaje.ACUATICA;
            break;
        case "Bosque Encantado":
            tipoPerjudicado = TipoPersonaje.TERRESTRE;
            break;
        case "Océano Profundo":
            tipoPerjudicado = TipoPersonaje.FUEGO;
            break;
        case "Caverna Rocosa":
            tipoPerjudicado = TipoPersonaje.VOLADOR;
            break;
        default:
            tipoPerjudicado = TipoPersonaje.TERRESTRE;
            break;
    }

    return new Arena(nombre, tipoBeneficiado, tipoPerjudicado);
}
    public string MostrarArena()
    {
        return $"Arena: {Nombre}  , Beneficiado: {TipoBeneficiado} , Perjudicado: {TipoPerjudiciado}";
    }
}