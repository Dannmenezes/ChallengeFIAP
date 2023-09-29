using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyChallenge;
using MoneyChallenge.Data;
using MoneyChallenge.Interfaces;
using MoneyChallenge.IoC;
using MoneyChallenge.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<FBIContext>(options => options.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IFBIService, FBIService>();
builder.Services.AddHttpClient();
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

void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<FBIService>(client =>
    {
        client.BaseAddress = new Uri("https://api.fbi.gov/wanted/v1/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // Another header's there
        client.DefaultRequestHeaders.Add("HeaderName", "HeaderValue");
    }); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
