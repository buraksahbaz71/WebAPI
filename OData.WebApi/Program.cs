using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.IO.Converters;
using Npgsql;
using OData.WebApi.Infrastructure.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Services 
    .AddControllers()
    .AddOData(conf =>
    {
        conf.EnableQueryFeatures();
    })
    .AddJsonOptions(opt =>
    opt.JsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory()));

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddDbContext<DurakDbContext>((sp, conf) =>
{
    conf.UseNpgsql(builder.Configuration.GetConnectionString("ConnStr"), 
        o => o.UseNetTopologySuite());

    conf.EnableSensitiveDataLogging();
});

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
