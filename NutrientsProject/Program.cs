using System;
using System.Configuration;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutrientsProject.Source;
using Pomelo.EntityFrameworkCore.MySql;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Console.WriteLine(builder.Configuration.GetSection("ConnectionStrings")["MysqlDatabase"]);

// Add service of database
var connectionString = builder.Configuration.GetConnectionString("MysqlDatabase");
// var serverVersion = new MySqlServerVersion(connectionString);
var serverVersion = new MySqlServerVersion(new MySqlServerVersion("5.7.35"));
builder.Services.AddDbContext<DatabaseContext>(dbContextOptions =>
    dbContextOptions.UseMySql(connectionString, serverVersion));

// var connectionString = builder.Configuration.GetConnectionString("PostgressDatabase");
// builder.Services.AddDbContext<DatabaseContext>(dbContextOptions =>
//     dbContextOptions.UseNpgsql(connectionString));

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.DisplayRequestDuration();
            c.InjectStylesheet("/dark.css");
        }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();