using Oracle.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hesol.Connection;
using Microsoft.OpenApi.Models;
using Hesol.Controllers;
using Hesol.Repository;
using Hesol.Service;

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
        Description = "Uma aplicação destinada ao controle de pessoas e professores através de rotas de api e integração com o banco de dados",
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

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<LeituraRepository>();
builder.Services.AddScoped<LeituraService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:8081")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirFrontend");


app.UseAuthorization();

app.MapControllers();

app.Run();







