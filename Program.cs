using MicroService.AppDBContext;
using MicroService.Handlers;
using MicroService.Interfaces;
using MicroService.Models;
using MicroService.Queries.Command_Model;
using MicroService.Queries.Query_Model;
using MicroService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("NorthwindDB")); // Replace with your database provider and connection string
});
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
builder.Services.AddTransient<IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>>, GetProductsQueryHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();

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
