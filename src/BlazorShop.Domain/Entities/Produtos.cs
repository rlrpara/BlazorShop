using BlazorShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities;

[Table("PRODUTO")]
public class Produtos : EntityBase
{
    [Nota(ChaveEstrangeira = "CATEGORIA")]
    [Column("ID_CATEGORIA", Order = 2)]
    public int CodigoCategoria { get; set; }

    [Nota(Indice = true)]
    [Column("NOME", Order = 3)]
    public string Nome { get; set; } = string.Empty;

    [Nota()]
    [Column("DESCRICAO", Order = 4)]
    public string Descricao { get; set; } = string.Empty;

    [Nota()]
    [Column("IMAGEM_URL", Order = 5)]
    public string ImagemUrl { get; set; } = string.Empty;

    [Nota()]
    [Column("PRECO", Order = 6)]
    public decimal Preco { get; set; } = 0;

    [Nota()]
    [Column("QUANTIDADE", Order = 7)]
    public int Quantidade { get; set; } = 1;
}
