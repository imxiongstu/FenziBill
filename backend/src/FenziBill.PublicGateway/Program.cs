using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddOcelot();
builder.Services.AddEndpointsApiExplorer();
//  ≈‰÷√ƒ¨»œøÁ”Ú
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins(
                configuration["CorsOrigins"]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();
//  ∆Ù”√øÁ”Ú
app.UseCors();
app.UseHttpsRedirection();
//  ∆Ù”√OcellotÕ¯πÿ
app.UseOcelot().Wait();
app.Run();