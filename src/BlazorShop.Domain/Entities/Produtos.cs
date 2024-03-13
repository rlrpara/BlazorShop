using BlazorShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities;

[Table("PRODUTO")]
public class Produtos : EntityBase
{
    [Nota(Indice = true)]
    [Column("NOME", Order = 2)]
    public string Nome { get; set; } = string.Empty;

    [Nota()]
    [Column("DESCRICAO", Order = 3)]
    public string Descricao { get; set; } = string.Empty;

    [Nota()]
    [Column("IMAGEM_URL", Order = 4)]
    public string ImagemUrl { get; set; } = string.Empty;

    [Nota()]
    [Column("PRECO", Order = 4)]
    public decimal Preco { get; set; } = 0;

    [Nota()]
    [Column("QUANTIDADE", Order = 5)]
    public int Quantidade { get; set; } = 1;
}
