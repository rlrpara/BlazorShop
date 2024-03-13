using BlazorShop.CrossCuttin.Util.ExtensionMethods;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities.Base;

public class EntityBase
{
    #region [Private Properties]
    private DateTime? _dataCadastro;
    private DateTime? _dataAtualizacao;
    private bool? _ativo;
    #endregion

    #region [Private Methods]
    private DateTime? ObterDataValida(DateTime? dataEntrada)
    {
        string? dataValida = dataEntrada?.ToString();

        if (string.IsNullOrWhiteSpace(dataValida))
            dataValida = DateTime.Now.ToString();

        return Convert.ToDateTime(dataValida);
    }
    #endregion

    #region [Constructor]
    public EntityBase()
    {
        _dataCadastro = DataCadastro;
        _dataAtualizacao = DataAtualizacao;
        _ativo = Ativo;
    }
    #endregion

    #region [Public Methods]
    [Key]
    [Nota()]
    [Column("ID", Order = 1)]
    public int? Codigo { get; set; }

    [Nota()]
    [Column("DATA_CADASTRO", Order = 100)]
    public DateTime? DataCadastro
    {
        get { return _dataCadastro; }
        set { _dataCadastro = ObterDataValida(value); }
    }

    [Nota()]
    [Column("DATA_ATUALIZACAO", Order = 101)]
    public DateTime? DataAtualizacao
    {
        get { return _dataAtualizacao; }
        set { _dataAtualizacao = value.ToString().DataValida() ? value : DateTime.Now; }
    }

    [Nota()]
    [Column("ATIVO", Order = 102)]
    public bool? Ativo
{
        get { return _ativo; }
        set { _ativo = value ?? false; }
    }

    #endregion
}
