using FluentValidation;
using SportsTeamManagement.Controllers;
using SportsTeamManagementData.Data;
using SportsTeamManagementData.Models;
using SportsTeamManagementData.Repositories.Players;
using SportsTeamManagementData.Repositories.Sport_Discipline;
using SportsTeamManagementData.Repositories.Teams;
using SportsTeamManagementData.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDbDataAccess, DbDataAccess>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ISport_DisciplineRepository, Sport_DisciplineRepository>();

//validations
builder.Services.AddScoped<IValidator<Player>, PlayerValidator>();
builder.Services.AddScoped<IValidator<Team>, TeamValidator>();
builder.Services.AddScoped<IValidator<Sport_DisciplineController>, Sport_DisciplineValidator>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
