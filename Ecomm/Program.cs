using AutoMapper;
using Ecomm.Data;
using Ecomm.Data.Mappers;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<EcommDbContext>();

builder.Services.AddFluentMigratorCore().ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString("EcommDbConnection")
                    .ScanIn(Assembly.Load("Ecomm.Data")).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ProductMapperProfile>();
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Ecomm.Domain")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();

var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

runner.MigrateUp();

var serviceProvider = app.Services;

app.UseHttpsRedirection();
app.MapControllers();

app.Run();