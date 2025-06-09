using EComBlazor.Classes;
using EComBlazor.db.Contexts;
using EComBlazor.db.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add services to the container.
builder.Host.UseSerilog();
Log.Logger.Information("Application just started .............");

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add injection options 
builder.Services.AddInjectionOptionsDb(builder.Configuration);
builder.Services.AddInjectionOptionsApi();

//CORS config 
builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader()
        .AllowAnyMethod()
        //.WithOrigins("https://localhost:27829");
        .AllowAnyOrigin()
        .AllowCredentials();
    });
});

try
{
    var app = builder.Build();
    app.UseCors();
    app.UseSerilogRequestLogging();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.AddMiddleWareDb();
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    Log.Logger.Information("Appliction Try to open ..........");
    app.Run();
    Log.Logger.Information("Appliction Now working fine ..........");
}
catch (Exception ex)
{
    Log.Logger.Error(ex, "Appliction has been stopped ...");
}
finally
{
    Log.Logger.Information("Appliction Now colsed ..........");
    Log.CloseAndFlush();
}
