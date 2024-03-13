
using BlazorShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities;

[Table("CARRINHO")]
public class Carrinho : EntityBase
{
    [Nota(ChaveEstrangeira = "USUARIO")]
    [Column("ID_USUARIO", Order = 2)]
    public int? CodigoUsuario { get; set; }
}
