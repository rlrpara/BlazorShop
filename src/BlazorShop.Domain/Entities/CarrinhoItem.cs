using BlazorShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities;

[Table("CARRINHO_ITEM")]
public class CarrinhoItem : EntityBase
{
    [Nota(Indice = true, ChaveEstrangeira = "CARRINHO")]
    [Column("ID_CARRINHO", Order = 2)]
    public int CodigoCarrinho { get; set; }

    [Nota(Indice = true, ChaveEstrangeira = "PRODUTO")]
    [Column("ID_PRODUTO", Order = 3)]
    public int CodigoProduto { get; set; }
    
    [Nota()]
    [Column("QUANTIDADE", Order = 3)]
    public int Quantidade { get; set; } = 1;
}
