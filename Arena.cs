public class Arena{
    private string nombre;
    private TipoPersonaje tipoBeneficiado ;
    private TipoPersonaje tipoPerjudiciado ;

    public Arena(string nombre, TipoPersonaje tipoBeneficiado, TipoPersonaje tipoPerjudiciado)
    {
        this.Nombre = nombre;
        this.TipoBeneficiado = tipoBeneficiado;
        this.TipoPerjudiciado = tipoPerjudiciado;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public TipoPersonaje TipoBeneficiado { get => tipoBeneficiado; set => tipoBeneficiado = value; }
    public TipoPersonaje TipoPerjudiciado { get => tipoPerjudiciado; set => tipoPerjudiciado = value; }

    public static Arena GenerarArenaAleatoria()
    {
        Random random = new Random();
        string[] nombres = { "Arena Volcánica", "Bosque Encantado", "Océano Profundo", "Caverna Rocosa" };
        TipoPersonaje[] tipos = { TipoPersonaje.FUEGO, TipoPersonaje.VOLADOR, TipoPersonaje.ACUATICA, TipoPersonaje.TERRESTRE };

        string nombre = nombres[random.Next(nombres.Length)];
        TipoPersonaje tipoBeneficiado = tipos[random.Next(tipos.Length)];
        TipoPersonaje tipoPerjudiciado;

        do
        {
            tipoPerjudiciado = tipos[random.Next(tipos.Length)];
        } while (tipoPerjudiciado == tipoBeneficiado);

        return new Arena(nombre, tipoBeneficiado, tipoPerjudiciado);
    }
    public string MostrarArena(){
        return $"Arena: {Nombre}  , Beneficiado: {TipoBeneficiado} , Perjudicado: {TipoPerjudiciado}";
    }
}