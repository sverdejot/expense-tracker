using Application;
using Infrastructure;
using Persistance;
using Persistance.Options;
using Serilog;
using WebAPI;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
builder.Services
    .ConfigureOptions<DatabaseOptionsSetup>();

// Add layers
builder.Services
    .AddApplication()
    .AddPersistance(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddMiddleware();
builder.Services.AddMappings();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app.UseCustomMiddlewares();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
