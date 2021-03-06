using System.Reflection;
using DomainModeling.Web;
using DomainModeling.Web.Endpoints.Encapsulated;
using MediatR;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

// Add services to the container.

builder.Services.AddControllers(options =>
{
  options.UseNamespaceRouteToken();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(typeof(DomainModeling.Web.BaseEntity).Assembly);
builder.Services.AddScoped<DataService>();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Domain Modeling", Version = "v1" });
  c.IncludeXmlComments(Program.XmlCommentsFilePath);
  c.CustomSchemaIds(x => x.FullName);
  c.UseApiEndpoints();
});
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

// Configure Sample Data

DomainModeling.Web.Endpoints.Anemic.Data.Seed(app.Logger);
DomainModeling.Web.Endpoints.AnemicV2.Data.Seed(app.Logger);
DataService.Seed(app.Logger);

app.Run();

public partial class Program
{
  static string XmlCommentsFilePath
  {
    get
    {
      var basePath = PlatformServices.Default.Application.ApplicationBasePath;
      var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
      return Path.Combine(basePath, fileName);
    }
  }
}
