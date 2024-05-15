using FluentValidation;
using SportsTeamManagementData.Data;
using SportsTeamManagementData.Models;
using SportsTeamManagementData.Repositories.Players;
using SportsTeamManagementData.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbDataAccess, DbDataAccess>();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

//validations
builder.Services.AddScoped<IValidator<Player>, PlayerValidator>();

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
