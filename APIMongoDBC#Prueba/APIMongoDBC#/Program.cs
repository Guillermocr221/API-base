using APIMongoDBC_.Models;
using APIMongoDBC_.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<VehiclesSettings>( //a la clase<VehiclesSettings> se le asignara el valor obtenido del Json
                   builder.Configuration.GetSection(nameof(VehiclesSettings)));//llama al Json VehiclesSettings y obtiene sus settings
//Implementacion de IVehiclesSettings
builder.Services.AddSingleton<IVehiclesSettings>(sp=>
    sp.GetRequiredService<IOptions<VehiclesSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("VehiclesSettings:Connection")));

builder.Services.AddScoped<IVehicleService, VehicleService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
