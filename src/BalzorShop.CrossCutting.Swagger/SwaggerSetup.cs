using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BlazorShop.CrossCutting.Swagger;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services) => services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Blazor Sop",
            Version = "v1",
            Description = "Sistema criado para estudo",
            Contact = new OpenApiContact
            {
                Name = "Equipe",
                Email = "blazorshop@blazorshop.com.br",
                Url = new Uri("http://www.questor.com.br")
            }
        });
        opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api-doc.xml"));
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
            BearerFormat = "JWT",
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            Description = "Informe **_APENAS_** seu JWT Bearer token na caixa abaixo.",

            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        opt.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });
    });
    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app) => app.UseSwagger().UseSwaggerUI(c =>
    {
        c.RoutePrefix = "documentation";
        c.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
    });
}
