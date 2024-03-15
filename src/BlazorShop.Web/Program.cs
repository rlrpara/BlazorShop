using BlazorShop.ServiceWeb.Interfaces;
using BlazorShop.ServiceWeb.Services;
using BlazorShop.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var baseUrl = "http://localhost:5097";

builder.Services.AddScoped(x => new HttpClient
{
    BaseAddress = new Uri(baseUrl)
});

builder.Services.AddScoped<IProdutoService, ProdutoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
