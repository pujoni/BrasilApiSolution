using Microsoft.OpenApi.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Repository.WeatherRepository;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<WeatherRepository>();


builder.Services.AddHttpClient<IWeatherService, BrasilApiServiceClient>(client =>
{
    client.BaseAddress = new Uri("https://brasilapi.com.br/");
});

builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Brasil API Service", Version = "v1" });
});


builder.Services.AddHttpClient<BrasilApiServiceClient>(client =>
{
    client.BaseAddress = new Uri("https://brasilapi.com.br/");
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Brasil API Service v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
