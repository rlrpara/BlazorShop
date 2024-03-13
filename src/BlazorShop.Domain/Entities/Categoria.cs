using BlazorShop.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities;

[Table("CATEGORIA")]
public class Categoria : EntityBase
{
    [Nota(Indice = true)]
    [Column("NOME", Order = 2)]
    public string Nome { get; set; } = string.Empty;

    [Nota()]
    [Column("ICON_CSS", Order = 3)]
    public string IconCSS { get; set; } = string.Empty;
}
