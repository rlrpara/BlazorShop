using BlazorShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorShop.CrossCuttin.Util.ExtensionMethods;

namespace BlazorShop.Domain.Entities;

[Table(name: "USUARIO")]
public class Login : EntityBase
{
    private string? _nome;
    private string? _email;
    private string? _senha;

    [Nota(Indice = true)]
    [Column(name: "NOME", Order = 2)]
    public string? Nome
    {
        get { return _nome; }
        set { _nome = value.RemoverAcentos(); }
    }

    [Nota(Tamanho = 50, Indice = true)]
    [Column(name: "EMAIL", Order = 3)]
    public string? Email
    {
        get { return _email; }
        set { _email = value?.ToLower(); }
    }

    [Nota(Tamanho = 50)]
    [Column(name: "SENHA", Order = 4)]
    public string? Senha
    {
        get { return _senha; }
        set { _senha = value; }
    }
}
