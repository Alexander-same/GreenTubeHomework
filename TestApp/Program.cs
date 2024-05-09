using Microsoft.Extensions.DependencyInjection;
using TestApp.Models;
using TestApp.Services.Interfaces;
using TestApp.Services.Interfaces.Player;
using TestApp.Services.Interfaces.Transaction;
using TestApp.Services.Interfaces.Wallet;
using TestApp.Services.Repositories;
using TestApp.Services.Transaction;
using TestApp.Services.Wallet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddTransient(typeof(IGenericReporistory<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IWalletReporitory, WalletRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();

builder.Services.AddTransient<IWalletService, WalletService>();

builder.Services.AddTransient<ITransactionStrategy, DepositTransactionStrategy>();
builder.Services.AddTransient<ITransactionStrategy, WinTransactionStrategy>();
builder.Services.AddTransient<ITransactionStrategy, StakeTransactionStrategy>();

builder.Services.AddScoped<TransactionProcessor>();

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
