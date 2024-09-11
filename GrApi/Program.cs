using AutoMapper;
using GrApi.Data;
using GrApi.Models;
using GrApi.Repository;
using GrApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddDbContext<UsuarioContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UsuarioContext>();

IMapper mapper = Mappings.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<UsuarioContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200") // Permite apenas a origem do seu frontend
            .AllowAnyMethod()                     // Permite todos os métodos HTTP (GET, POST, etc.)
            .AllowAnyHeader()                     // Permite todos os headers
            .AllowCredentials();                  // Permite o envio de cookies e credenciais
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

app.UseCors("PermitirTudo");

app.UseAuthorization();

app.MapControllers();

app.Run();
