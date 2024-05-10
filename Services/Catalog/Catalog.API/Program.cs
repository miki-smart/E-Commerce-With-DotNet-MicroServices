using Catalog.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


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
app.Run();
