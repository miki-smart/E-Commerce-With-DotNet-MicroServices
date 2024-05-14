using Catalog.Core.Repository;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repository;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddControllers();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Catalog.API", Version = "v1" });
});

builder.Services.AddMvc();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
           .AllowAnyMethod()
                  .AllowAnyHeader());
});
var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});
app.Run();
