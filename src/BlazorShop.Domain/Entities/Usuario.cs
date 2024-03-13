using BlazorShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities;

[Table("USUARIO")]
public class Usuario : EntityBase
{
    #region [Private Properties]
    private string? _email;
    private string? _senha;
    #endregion

    #region [Constructor]
    public Usuario()
    {
        _email = Email;
        _senha = Senha;
    }
    #endregion

    #region [Public Methods]
    [Nota(Indice = true)]
    [Column("EMAIL", Order = 2)]
    public string? Email
    {
        get { return _email; }
        set { _email = value?.ToLower(); }
    }

    [Nota()]
    [Column("SENHA", Order = 3)]
    public string? Senha
    {
        get { return _senha; }
        set { _senha = value; }
    }

    [Nota()]
    [Column("NOME", Order = 4)]
    public string Nome { get; set; }

    [Nota()]
    [Column("ADMIN", Order = 5)]
    public bool Admin { get; set; }
    #endregion
}
