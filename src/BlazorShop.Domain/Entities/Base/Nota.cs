namespace BlazorShop.Domain.Entities.Base;

public class Nota : Attribute
{
    public bool ChavePrimaria { get; set; } = false;
    public bool UsarNoBancoDeDados { get; set; } = true;
    public bool UsarParaBuscar { get; set; } = true;
    public string ChaveEstrangeira { get; set; } = "";
    public int Tamanho { get; set; } = 255;
    public bool Indice { get; set; } = false;
}
