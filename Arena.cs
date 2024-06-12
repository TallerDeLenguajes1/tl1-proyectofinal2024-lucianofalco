public class Arena{
    private string nombre;
    private TipoPersonaje tipoBeneficiado ;
    private TipoPersonaje tipoPerjudiciado ;

    public Arena(string nombre, TipoPersonaje tipoBeneficiado, TipoPersonaje tipoPerjudiciado)
    {
        this.nombre = nombre;
        this.tipoBeneficiado = tipoBeneficiado;
        this.tipoPerjudiciado = tipoPerjudiciado;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public TipoPersonaje TipoBeneficiado { get => tipoBeneficiado; set => tipoBeneficiado = value; }
    public TipoPersonaje TipoPerjudiciado { get => tipoPerjudiciado; set => tipoPerjudiciado = value; }
}