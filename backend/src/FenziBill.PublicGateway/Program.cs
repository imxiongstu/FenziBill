using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddOcelot();
builder.Services.AddEndpointsApiExplorer();
//  ����Ĭ�Ͽ���
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
//  ���ÿ���
app.UseCors();
app.UseHttpsRedirection();
//  ����Ocellot����
app.UseOcelot().Wait();
app.Run();