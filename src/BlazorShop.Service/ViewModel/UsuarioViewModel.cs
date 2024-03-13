namespace BlazorShop.Service.ViewModel;

public class UsuarioViewModel
{
    public int? Codigo { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Foto { get; set; }
    public bool Admin { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public bool? Ativo { get; set; }
}
