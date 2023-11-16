using System.Reflection;
using Valemas.Infrastructure.Users;

var builder = WebApplication.CreateBuilder(args);
var applicationAssembly = Assembly.Load("Valemas.Application");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddHttpClient()
    .AddUserPersistence()
    .ConfigureUserEndpoint(builder.Configuration)
    .AddMediatR(configuration => configuration.RegisterServicesFromAssembly(applicationAssembly));

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
