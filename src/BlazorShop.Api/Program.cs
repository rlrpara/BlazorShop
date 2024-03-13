using BlazorShop.Api;
using BlazorShop.CrossCutting.Iot;
using BlazorShop.CrossCutting.Swagger;
using BlazorShop.Infra.Database;
using BlazorShop.Service.AutoMapper;
using System.Text.Json.Serialization;
using BlazorShop.CrossCutting.Auth; ;

DotEnvLoad.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
.AddJsonOptions(x =>
{
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
})
.AddNewtonsoftJson(x =>
{
    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

new DatabaseConfiguration().GerenciarBanco();

builder.Services.AuthAuthenticationBlazor();
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));
builder.Services.RegisterServices();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
{
    x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
