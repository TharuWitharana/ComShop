using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Configuration;
using ComputerShop.Models;
using ComputerShop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionstring = builder.Configuration.GetConnectionString(name: "DefaultConnection");
builder.Services.AddDbContext<ComputerContext>(options =>
{
    //options.UseMySql(connectionstring,  ServerVersion.Parse(connectionstring));
    options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
});

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

//app.MapAdminEndpoints();

app.Run();