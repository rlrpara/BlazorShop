using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Domain.Entities.Base;

public class EntityBase
{
    [Key]
    [Nota()]
    [Column("ID", Order = 1)]
    public int? Codigo { get; set; }

    [Nota()]
    [Column("DATA_CADASTRO", Order = 100)]
    public DateTime? DataCadastro { get; set; }

    [Nota()]
    [Column("DATA_ATUALIZACAO", Order = 101)]
    public DateTime? DataAtualizacao { get; set; }

    [Nota()]
    [Column("ATIVO", Order = 102)]
    public bool Ativo { get; set; }
}
