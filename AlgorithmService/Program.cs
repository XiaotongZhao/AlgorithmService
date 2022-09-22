using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AlgorithmService.Domain.Algorithms.DynamicPlanning;
using AlgorithmService.Domain.Algorithms.QuickSort.Service;
using AlgorithmService.Domain.Tree.BinaryTree.Service;
using AlgorithmService.Domain.Tree.RedBlackTree.Service;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
implementDiByScanLibrary(services);
services.AddScoped<IQuickSortService, QuickSortService>();
services.AddScoped<IDynamicPlanningService, DynamicPlanningService>();
services.AddScoped<IBinaryTreeService, BinaryTreeService>();
services.AddScoped<IRedBlackTreeService, RedBlackTreeService>();

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

static void implementDiByScanLibrary(IServiceCollection services)
{
    var interfaceAndImplementClass = Assembly.Load("AlgorithmService.Domain").GetTypes()
        .Where(type => type.IsClass && type.GetInterfaces().Length > 0)
        .Select(type => new { ImplementInterfaceClass = type, Interfaces = type.GetInterfaces().ToList() }).ToList();
}