using Basis.CodeChallenge.API.Extensions;
using Basis.CodeChallenge.API.Filters;
using Basis.CodeChallenge.API.Services;
using Basis.CodeChallenge.API.Services.Interfaces;
using Basis.CodeChallenge.API.ViewModels.Livro;
using Basis.CodeChallenge.Domain.Interfaces.Notifications;
using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Domain.Notifications;
using Basis.CodeChallenge.Infra.Context;
using Basis.CodeChallenge.Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using System.Collections.Concurrent;
using System.Data.Common;
using System.IO.Compression;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Configure services
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddControllers();
builder.Services.AddMvc(options =>
{
    options.Filters.Add<DomainNotificationFilter>();
    options.EnableEndpointRouting = false;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);
builder.Services.AddResponseCompression(x =>
{
    x.Providers.Add<GzipCompressionProvider>();
});

var hostEnvironment = builder.Environment;

//poetic license to academic environment
//if (!hostEnvironment.IsProduction())
//{
builder.Services.AddOpenApiDocument(document =>
{
    document.DocumentName = "v1";
    document.Version = "v1";
    document.Title = "Felipe's CodeChallenge API";
    document.Description = "API CodeChallenge";
    
    document.PostProcess = (configure) =>
    {
        configure.Info.TermsOfService = "None";
        configure.Info.Contact = new OpenApiContact()
        {
            Name = "Felipe",
            Email = "neperz@gmail.com",
            Url = "https://github.com/neperz/Basis.CodeChalenge"
        };
        configure.Info.License = new OpenApiLicense()
        {
            Name = "Free to copy",
            Url = "https://felipe.wikicode.com.br"
        };
        
        configure.Servers.Add(new OpenApiServer
        {
            Url = "http://api:9999",
            Description = "Nginx Proxy Server"
        });
    };
});
//}

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Basis.CodeChallenge.Infra.Mappings.DbMapper));
builder.Services.AddScoped<IBasisLivroService, BasisLivroService>();
builder.Services.AddSingleton(_ => new ConcurrentDictionary<int, BasisLivroViewModel>());

builder.Services.AddScoped<IDomainNotification, DomainNotification>();


builder.Services.AddScoped<IBasisLivroRepository, LivroRepository>();


builder.Services.AddDbContext<EntityContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("LivroDB"));
    options.EnableSensitiveDataLogging();
}
    );

builder.Services.AddSingleton<DbConnection>(conn =>
    new SqliteConnection(builder.Configuration.GetConnectionString("LivroDB")));

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<EntityContextSeed>();



var app = builder.Build();
app.MapGet("/ping", () => new { info = "pong" });

 
app.UseDeveloperExceptionPage();
app.UseDatabaseValidation();
app.UseDatabaseSeed();
 
app.UseRouting(); 
app.UseResponseCompression();
 
app.UseOpenApi();

app.UseSwaggerUI();


app.MapControllers();
app.UseCors(builder => builder

                .SetIsOriginAllowed(_ => true)

                //"http://api:9999",                
                //)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(context =>
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = context.Request.ContentType;
        context.Response.Body = context.Request.Body;
        return Task.CompletedTask;
    });
});

app.Run();

public partial class Program { }