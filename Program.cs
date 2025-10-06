using Microsoft.EntityFrameworkCore;
using Hesol.Connection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API REST Hesol",
        Description = "Uma aplicação destinada à prevenção do aquecimento global através de cálculos da qualidade ambiental para soluções preventivas",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

string Req(string name)
{
    var v = Environment.GetEnvironmentVariable(name);
    if (string.IsNullOrWhiteSpace(v))
        throw new InvalidOperationException($"Variável de ambiente '{name}' não definida.");
    return v;
}

var dbHost = Req("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "1433";
var dbName = Req("DB_NAME");
var dbUser = Req("DB_USER");
var dbPassword = Req("DB_PASSWORD");

// Connection string no formato Azure SQL
var connectionString =
    $"Server=tcp:{dbHost},{dbPort};" +
    $"Initial Catalog={dbName};" +
    $"Persist Security Info=False;" +
    $"User ID={dbUser};" +
    $"Password={dbPassword};" +
    $"MultipleActiveResultSets=False;" +
    $"Encrypt=True;" +
    $"TrustServerCertificate=False;" +
    $"Connection Timeout=30;";

// Para debug (sem senha)
Console.WriteLine($"[DB] Server={dbHost},{dbPort}; Database={dbName}; User={dbUser}");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Aplica TODAS as migrations pendentes no banco configurado (Azure neste caso)
    await db.Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("PermitirTudo");
app.UseAuthorization();
app.MapControllers();
app.Run();







