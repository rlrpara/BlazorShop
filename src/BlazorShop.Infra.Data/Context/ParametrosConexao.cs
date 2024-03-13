namespace BlazorShop.Infra.Data.Context;

public class ParametrosConexao
{
    private string? _nomeBanco;


    public string? Servidor { get; set; } = "";
    public string? Porta { get; set; } = "";
    public string? NomeBanco
    {
        get { return _nomeBanco?.ToLower(); }
        set => _nomeBanco = value ?? "";
    }
    public string? Usuario { get; set; } = "";
    public string? Senha { get; set; } = "";
    public int TipoBanco { get; set; } = 0;
}
