using ApiZoo.Repository;
using ApiZoo.Services;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Data;
using ZooAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionstring = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<IRepository<Animal>, AnimalRepository>();
builder.Services.AddScoped<IRepository<Specie>, SpecieRepository>();
builder.Services.AddScoped<IServiceAnimal, ServiceAnimal>();
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
