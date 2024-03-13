namespace BlazorShop.CrossCutting.Auth;

public static class Settings
{
    public static string? SEGREDO = Environment.GetEnvironmentVariable("SEGREDO") ?? string.Empty;
}
