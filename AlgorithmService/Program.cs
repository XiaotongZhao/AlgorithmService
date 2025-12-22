using Elastic.Serilog.Sinks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
ConfigureLogging();
builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
implementDIByScanLibrary(services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => $"Deploy AlgorithmService Successful  !!!! the env is {environment}");

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


void ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{environment}.json",
            optional: true)
        .Build();

    var elasticAddress = configuration["ElasticConfiguration:Uri"];
    var userName = configuration["ElasticConfiguration:UserName"] ?? string.Empty;
    var password = configuration["ElasticConfiguration:PassWord"] ?? string.Empty;
    if (!string.IsNullOrEmpty(elasticAddress) && !string.IsNullOrEmpty(environment))
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(ConfigureElasticSink(elasticAddress, userName, password, environment))
            .Enrich.WithProperty("Environment", environment)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    else
        Log.Logger = new LoggerConfiguration()
          .Enrich.FromLogContext()
          .WriteTo.Console()
          .Enrich.WithProperty("Environment", environment)
          .ReadFrom.Configuration(configuration)
          .CreateLogger();
}

Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions ConfigureElasticSink(string elasticAddress, string userName, string password, string environment)
{
    var index = $"{Assembly.GetExecutingAssembly()?.GetName()?.Name?.ToLower()}-{environment?.ToLower()}-{DateTime.UtcNow:yyyy-MM}";
    return new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri(elasticAddress))
    {
        AutoRegisterTemplate = true,
        IndexFormat = index,
        ModifyConnectionSettings = connection =>
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                connection.BasicAuthentication(userName, password);
            else
                connection
                .ServerCertificateValidationCallback((o, certificate, chain, errors) => true)
                .DisableAutomaticProxyDetection();
            return connection;
        }
    };
}