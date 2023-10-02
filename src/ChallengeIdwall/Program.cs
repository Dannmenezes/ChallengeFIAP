using ChallengeIdwall.Interfaces;
using ChallengeIdwall.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using static ChallengeIdwall.Context.ChallengeDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseOracle(connectionString).EnableSensitiveDataLogging(true));

builder.Services.AddControllers();
builder.Services.AddTransient<IWantedService, WantedService>();
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
app.UseCors("AllowLocalhost5173");

void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient<WantedService>(client =>
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