using ConsultorioApi.Data;
using ConsultorioApi.Repositories;
using ConsultorioApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Banco
var appData = Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData);

var folder = Path.Combine(appData, "Consultorio");

Directory.CreateDirectory(folder);

var dbPath = Path.Combine(folder, "consultorio.db");

builder.Services.AddDbContext<ConsultorioContext>(options =>
    options
        .UseLazyLoadingProxies()
        .UseSqlite($"Data Source={dbPath}"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<PacienteRepository>();
builder.Services.AddScoped<ProntuarioRepository>();


// Services
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<ProntuarioService>();


var app = builder.Build();

// Database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<ConsultorioContext>();

    db.Database.Migrate();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// HTTP pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();