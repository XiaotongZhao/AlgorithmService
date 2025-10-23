using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
implementDIByScanLibrary(services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void implementDIByScanLibrary(IServiceCollection services)
{
    var interfacesAndImplementClasses = Assembly.Load("AlgorithmService.Domain").GetTypes()
        .Where(type => type.IsClass && type.GetInterfaces().Length > 0)
        .Select(type => new { ImplementInterfaceClass = type, Interfaces = type.GetInterfaces().ToList() }).ToList();

    foreach (var interfaceClass in interfacesAndImplementClasses)
    {
        interfaceClass.Interfaces.ForEach(Interface => 
        {
            services.AddScoped(Interface, interfaceClass.ImplementInterfaceClass);
        });
    }

}