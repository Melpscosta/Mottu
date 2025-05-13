using Microsoft.EntityFrameworkCore;
using Mottu.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco de dados Oracle
builder.Services.AddDbContext<MotoDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// Adiciona suporte ao Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mottu API",
        Version = "v1",
        Description = "Documentação da API da Mottu"
    });
});

// Adiciona suporte a Razor Pages (frontend)
builder.Services.AddRazorPages();
builder.Services.AddControllers(); // <-- Adicionado aqui

var app = builder.Build();

// Configura o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Ativa Swagger e Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mottu API V1");
    c.RoutePrefix = "swagger"; // Acessível em /swagger
});

// Mapeia controladores e páginas
app.MapControllers(); // <-- Adicionado aqui
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
