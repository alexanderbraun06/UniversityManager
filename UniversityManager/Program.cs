using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using UniversityManager.Data;
using UniversityManager.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string connStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddSqlServer<UniDbContext>(connStr);

builder.Services.AddSingleton<Mapper>();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetService<UniDbContext>();
    ctx?.Database.Migrate();
    
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
