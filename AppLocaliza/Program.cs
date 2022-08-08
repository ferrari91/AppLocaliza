using AppLocaliza.Middleware;
using Localiza.Repository.Interface;
using Localiza.Repository.Repository;
using Localiza.Service.IService;
using Localiza.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
builder.Services.AddScoped<IRepositoryCliente, RepositoryCliente>();

builder.Services.AddScoped<IServiceVeiculo, ServiceVeiculo>();
builder.Services.AddScoped<IRepositoryVeiculo, RepositoryVeiculo>();

builder.Services.AddScoped<IServiceUsuario, ServiceUsuario>();
builder.Services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();

builder.Services.AddScoped<IServiceLocacao, ServiceLocacao>();
builder.Services.AddScoped<IRepositoryLocacao, RepositoryLocacao>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<MyJwtMiddleware>();

app.MapControllers();

app.Run();
