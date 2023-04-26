using System.Reflection;
using FluentValidation.AspNetCore;
using Logiwa.ProductService.Application.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Services.AddControllers()
    .AddFluentValidation(ValidationExtensions.Register);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.Register();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


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