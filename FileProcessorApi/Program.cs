using FileProcessorApplication.UsesCases;
using FileProcessorDomain.Ports;
using FileProcessorInfrastructure.Context;
using FileProcessorInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Configuración del DbContext con SQL Server
builder.Services.AddDbContext<RecordsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de dependencias
builder.Services.AddScoped<IFileProcessorRepository, FileProcessorRepository>();
builder.Services.AddScoped<FileRecord>();

// Configuración de controladores
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
