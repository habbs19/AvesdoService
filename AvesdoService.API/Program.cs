using AvesdoService.Core;
using AvesdoService.Core.Interfaces;
using AvesdoService.Core.Models;
using AvesdoService.Infrastructure.Repository;
using AvesdoService.Infrastructure.Services;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IOrderRepository<OrderModel>, OrderRepository>();
builder.Services.AddTransient<IInvoiceRepository<InvoiceModel>, InvoiceRepository>();
builder.Services.AddTransient<IDatabase<SqlParameter>>(factory => new MSSQL(builder.Configuration.GetConnectionString("Avesdo")));

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
