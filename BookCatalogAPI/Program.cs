using Microsoft.EntityFrameworkCore;
using BookCatalogAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conMysql = builder.Configuration.GetConnectionString("ConnectionMySql");

builder.Services.AddDbContext<libdbContext>(options => options.UseMySql(
    conMysql,
    ServerVersion.Parse("8.0.34")
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
